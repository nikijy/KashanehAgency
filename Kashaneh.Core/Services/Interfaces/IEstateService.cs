using System;
using System.Collections.Generic;
using System.Text;
using Kashaneh.DataLayer.Entities.Estate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kashaneh.Core.Services.Interfaces
{
   public interface IEstateService
   {
       List<SelectListItem> GetCityForManageEstate();
       List<SelectListItem> GetSubCityForManageEstate(int cityId);

       List<SelectListItem> GetEstateTypeForManageEstate();
       List<SelectListItem> GetSubEstateTypeForManageEstate(int typeId);
       int AddEstate(Estate estate,string userName, IEnumerable<IFormFile> images);
   }
}
