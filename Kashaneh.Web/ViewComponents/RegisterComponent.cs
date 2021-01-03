using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kashaneh.Core.Convertors;
using Kashaneh.Core.DTOs;
using Kashaneh.Core.Generator;
using Kashaneh.Core.Security;
using Kashaneh.Core.Senders;
using Kashaneh.Core.Services.Interfaces;
using Kashaneh.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace Kashaneh.Web.ViewComponents
{
    public class RegisterComponent : ViewComponent
    {
        private IUserService _userService;
        private IViewRenderService _viewRender;

        public RegisterComponent(IUserService userService, IViewRenderService viewRender)
        {
            _userService = userService;
            _viewRender = viewRender;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_Register"));
        }

    }
}