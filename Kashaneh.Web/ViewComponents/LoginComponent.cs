using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kashaneh.Core.Convertors;
using Kashaneh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kashaneh.Web.ViewComponents
{
    public class LoginComponent:ViewComponent
    {
        private IUserService _userService;
        private IViewRenderService _viewRender;

        public LoginComponent(IUserService userService, IViewRenderService viewRender)
        {
            _userService = userService;
            _viewRender = viewRender;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult) View("_Login"));
        }
    }
}
