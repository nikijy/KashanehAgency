using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kashaneh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kashaneh.DataLayer.Context;
using Kashaneh.DataLayer.Entities.Estate;
using Microsoft.AspNetCore.Http;

namespace Kashaneh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EstatesController : Controller
    {
        private readonly KashanehContext _context;
        private IEstateService _estateService;
        private IUserService _userService;

        public EstatesController(KashanehContext context, IEstateService estateService, IUserService userService)
        {
            _context = context;
            _estateService = estateService;
            _userService = userService;
        }

        // GET: Admin/Estates
        public async Task<IActionResult> Index()
        {
            var kashanehContext = _context.Estates
                .Include(e => e.City)
                .Include(e => e.EstateType)
                .Include(e => e.User)
                .Include(p => p.EstateImages);
            return View(await kashanehContext.ToListAsync());
        }

        // GET: Admin/Estates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estate = await _context.Estates
                .Include(e => e.City)
                .Include(e => e.EstateType)
                .Include(e => e.User)
                .Include(p => p.EstateImages.First())
                .FirstOrDefaultAsync(m => m.EstateId == id);
            if (estate == null)
            {
                return NotFound();
            }

            return View(estate);
        }

        // GET: Admin/Estates/Create
        public IActionResult Create()
        {
            var cities = _estateService.GetCityForManageEstate();
            ViewData["Cities"] = new SelectList(cities, "Value", "Text");
            var subCities = _estateService.GetSubCityForManageEstate(int.Parse(cities.First().Value));
            ViewData["SubCities"] = new SelectList(subCities, "Value", "Text");


            var types = _estateService.GetEstateTypeForManageEstate();
            ViewData["Types"] = new SelectList(types, "Value", "Text");
            var subTypes = _estateService.GetSubEstateTypeForManageEstate(int.Parse(types.First().Value));
            ViewData["SubTypes"] = new SelectList(subTypes, "Value", "Text");

            ViewData["Status"] = new SelectList(_context.EstateStatuses, "StatusId", "Title");

            return View();
        }

        // POST: Admin/Estates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstateId,EstateTypeId,SubEstateType,Region,StatusId,CityId,Price,CreateDuration,Area,BedRooms,BathRooms,Floors,Address,ShortDescription,Description,Tags,Facilities")] Estate estate, IEnumerable<IFormFile> images)
        {
            var userId = _userService.GetUserIdByUserName(User.Identity.Name);
            estate.UserId = userId;
            estate.IsDeleted = false;
            estate.CreateDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(estate);
                await _context.SaveChangesAsync();
                if (images.Any())
                {
                    foreach (var files in images)
                    {
                        var fileName = Path.GetFileName(files.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\EstateImages", fileName);
                        await using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await files.CopyToAsync(fileSteam);
                        }
                        EstateImage estateImage = new EstateImage()
                        {
                            EstateId = estate.EstateId,
                            Image = fileName
                        };

                        await _context.EstateImages.AddAsync(estateImage);
                    }
                }


                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", estate.CityId);
            ViewData["EstateTypeId"] = new SelectList(_context.EstateTypes, "EstateTypeId", "Type", estate.EstateTypeId);
            // ViewData["SubCities"] = new SelectList(_context.EstateTypes, "EstateTypeId", "Type", estate.EstateTypeId);
            // ViewData["EstateTypeId"] = new SelectList(_context.EstateTypes, "EstateTypeId", "Type", estate.EstateTypeId);

            return View(estate);
        }

        // GET: Admin/Estates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estate = await _context.Estates.FindAsync(id);
            if (estate == null)
            {
                return NotFound();
            }
            var cities = _estateService.GetCityForManageEstate();
            ViewData["Cities"] = new SelectList(cities, "Value", "Text");
            var subCities = _estateService.GetSubCityForManageEstate(int.Parse(cities.First().Value));
            ViewData["SubCities"] = new SelectList(subCities, "Value", "Text");


            var types = _estateService.GetEstateTypeForManageEstate();
            ViewData["Types"] = new SelectList(types, "Value", "Text");
            var subTypes = _estateService.GetSubEstateTypeForManageEstate(int.Parse(types.First().Value));
            ViewData["SubTypes"] = new SelectList(subTypes, "Value", "Text");

            ViewData["Status"] = new SelectList(_context.EstateStatuses, "StatusId", "Title");
            return View(estate);
        }

        // POST: Admin/Estates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstateId,EstateTypeId,SubEstateType,Region,StatusId,CityId,Price,CreateDuration,Area,BedRooms,BathRooms,Floors,Address,ShortDescription,Description,Tags,Facilities")] Estate estate, IEnumerable<IFormFile> images)
        {
            int userId = _userService.GetUserIdByUserName(User.Identity.Name);

            var pics = _context.EstateImages
                .Where(e => e.EstateId == estate.EstateId)
                .ToList();

            estate.UserId = userId;
            estate.CreateDate = DateTime.Now;
            estate.IsDeleted = false;
            if (id != estate.EstateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (!images.Any())
                {
                    estate.EstateImages = pics;
                }

                if (images.Any())
                {
                    string imagePath = "";
                    foreach (var names in pics)
                    {
                        imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\EstateImages",
                            names.Image);
                       
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);

                            _context.EstateImages.Remove(names);
                        }
                    }


                    foreach (var file in images)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\EstateImages", fileName);
                            await using (var fileSteam = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileSteam);
                            }


                            EstateImage estateImage = new EstateImage()
                            {
                                EstateId = id,
                                Image = fileName
                            };
                            _context.EstateImages.Update(estateImage);
                            await _context.SaveChangesAsync();
                        }
                    }
                }

                try
                {
                    _context.Update(estate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstateExists(estate.EstateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityName", estate.CityId);
            ViewData["EstateTypeId"] = new SelectList(_context.EstateTypes, "EstateTypeId", "Type", estate.EstateTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", estate.UserId);
            return View(estate);
        }

        // GET: Admin/Estates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estate = await _context.Estates
                .Include(e => e.City)
                .Include(e => e.EstateType)
                .Include(e => e.User)
                .Include(p => p.EstateImages.First())
                .FirstOrDefaultAsync(m => m.EstateId == id);
            if (estate == null)
            {
                return NotFound();
            }

            return View(estate);
        }

        // POST: Admin/Estates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estate = await _context.Estates.FindAsync(id);
            estate.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstateExists(int id)
        {
            return _context.Estates.Any(e => e.EstateId == id);
        }
    }
}
