namespace NaturalForum.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    using Web.ViewModels.User;
    using Services.Data.Interfaces;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<UserServiceViewModel> users = await this.userService
                .GetAllUsersAsync();

            return View(users);
        }
    }
}
