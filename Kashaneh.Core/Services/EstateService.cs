using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kashaneh.Core.Services.Interfaces;
using Kashaneh.DataLayer.Context;
using Kashaneh.DataLayer.Entities.Estate;
using Kashaneh.DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kashaneh.Core.Services
{
   public class EstateService:IEstateService
   {
       private KashanehContext _context;
       private IUserService _userService;

       public EstateService(KashanehContext context, IUserService userService)
       {
           _context = context;
           _userService = userService;
       }

        public List<SelectListItem> GetCityForManageEstate()
        {
            return _context.Cities.Where(c => c.ParentId == null)
                .Select(c => new SelectListItem()
                {
                    Text = c.CityName,
                    Value = c.CityId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetSubCityForManageEstate(int cityId)
        {
            return _context.Cities.Where(c => c.ParentId == cityId)
                .Select(c => new SelectListItem()
                {
                    Text = c.CityName,
                    Value = c.CityId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetEstateTypeForManageEstate()
        {
            return _context.EstateTypes.Where(t => t.ParentId == null)
                .Select(t => new SelectListItem()
                {
                    Text = t.Type,
                    Value = t.EstateTypeId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetSubEstateTypeForManageEstate(int typeId)
        {
            return _context.EstateTypes.Where(t => t.ParentId == typeId)
                .Select(t => new SelectListItem()
                {
                    Text = t.Type,
                    Value = t.EstateTypeId.ToString()
                }).ToList();
        }

        public int AddEstate(Estate estate,string userName, IEnumerable<IFormFile> images)
        {
            var userId = _userService.GetUserIdByUserName(userName);
            estate =new Estate()
            {
                Address = estate.Address,
                Area = estate.Area,
                BathRooms = estate.BathRooms,
                BedRooms = estate.BedRooms,
                CreateDate = DateTime.Now,
                CreateDuration = estate.CreateDuration,
                Description = estate.Description,
                Facilities = estate.Facilities,
                ShortDescription = estate.ShortDescription,
                Floors = estate.Floors,
                Price = estate.Price,
                Tags = estate.Tags,
                
            };
            return estate.EstateId;
        }
   }
}
