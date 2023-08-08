namespace NaturalForum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using Services.Data.Interfaces;
    using Web.ViewModels.Tree;

    using static Common.NotificationMessagesConstants;
    using static Common.GeneralApplicationConstants;
    public class TreeController : Controller
    {
        private readonly ITreeService treeService;
        private readonly IMemoryCache memoryCache;

        public TreeController(ITreeService treeService,
            IMemoryCache memoryCache)
        {
            this.treeService = treeService;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<TreeViewModel> trees = this.memoryCache
                .Get<IEnumerable<TreeViewModel>>(TreeCacheKey);

            if (trees == null)
            {
                trees = await this.treeService
                    .AllTreesAsync();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(WikiCacheDurationMinutes));

                this.memoryCache.Set(TreeCacheKey, trees, cacheOptions);
            }

            return View(trees);
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
