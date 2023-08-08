namespace NaturalForum.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Web.ViewModels.User;
    using Services.Data.Interfaces;
    using System.Collections.Generic;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<UserServiceViewModel> viewModel = await this.userService
                .GetAllUsersAsync();

            return View(viewModel);
        }
    }
}
