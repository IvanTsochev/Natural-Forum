namespace NaturalForum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Tree;
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
    }
}
