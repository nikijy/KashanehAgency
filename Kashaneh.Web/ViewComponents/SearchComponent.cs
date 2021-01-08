using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kashaneh.Web.ViewComponents
{
    public class SearchComponent:ViewComponent
    {


        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_Search"));
        }
    }
}
