using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kashaneh.Core.Services.Interfaces
{
   public interface IEstateService
   {
       List<SelectListItem> GetCityForManageEstate();
       List<SelectListItem> GetSubCityForManageEstate(int cityId);

       List<SelectListItem> GetEstateTypeForManageEstate();
       List<SelectListItem> GetSubEstateTypeForManageEstate(int typeId);
    }
}
