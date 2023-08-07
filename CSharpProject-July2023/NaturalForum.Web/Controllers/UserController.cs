namespace NaturalForum.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using Web.ViewModels.User;

    using static Infrastructure.Extensions.ClaimsPrincipalExtensions;

    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            Guid userId = Guid.Parse(User.GetId()!);

            UserProfileViewModel viewModel = 
                await this.userService.GetUserProfileAsync(userId);

            return View(viewModel);
        }
    }
}
