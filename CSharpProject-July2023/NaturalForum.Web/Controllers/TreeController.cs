namespace NaturalForum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Tree;

    using static Common.NotificationMessagesConstants;
    public class TreeController : Controller
    {
        private readonly ITreeService treeService;

        public TreeController(ITreeService treeService)
        {
            this.treeService = treeService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<TreeViewModel> viewModel =
                await this.treeService.AllTreesAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            bool treeExist = await this.treeService.TreeExistByIdAsync(id);

            if (!treeExist)
            {
                TempData[ErrorMessage] = "We do not found this tree! Try again, later!";

                return RedirectToAction("All", "Tree");
            }

            TreeDetailsViewModel viewModel =
                await this.treeService.GetTreeDetailsAsync(id);

            return View(viewModel);
        }
    }
}
