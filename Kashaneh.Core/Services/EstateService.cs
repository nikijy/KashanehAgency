using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kashaneh.Core.Services.Interfaces;
using Kashaneh.DataLayer.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kashaneh.Core.Services
{
   public class EstateService:IEstateService
   {
       private KashanehContext _context;

       public EstateService(KashanehContext context)
       {
           _context = context;
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
   }
}
