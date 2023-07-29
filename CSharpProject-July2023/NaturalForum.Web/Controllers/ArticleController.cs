namespace NaturalForum.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Article;

    using static Infrastructure.Extensions.ClaimsPrincipalExtensions;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<ArticleViewModel> viewModel = 
                await this.articleService.AllArticlesAsync();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ArticleFormViewModel viewModel = new ArticleFormViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "There was an error!";

                return View(model);
            }

            try
            {
                this.articleService.CreateArticleAsync(model, User.GetId());

                TempData[SuccessMessage] = "House was added successfully!";
                return RedirectToAction("All", "Article");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new house! Please try again later or contact administrator!");

                return View(model);
            }
        }
    }
}
