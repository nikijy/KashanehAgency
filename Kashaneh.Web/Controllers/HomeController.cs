using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kashaneh.Core.Convertors;
using Kashaneh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kashaneh.Web.Controllers
{
    public class HomeController : Controller
    {
        private IEstateService _estateService;

        public HomeController(IEstateService estateService)
        {
            _estateService = estateService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSubCity(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            list.AddRange(_estateService.GetSubCityForManageEstate(id));
            return Json(new SelectList(list, "Value", "Text"));
        }

        public IActionResult GetSubTypes(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            list.AddRange(_estateService.GetSubEstateTypeForManageEstate(id));
            return Json(new SelectList(list, "Value", "Text"));
        }

    }
}
