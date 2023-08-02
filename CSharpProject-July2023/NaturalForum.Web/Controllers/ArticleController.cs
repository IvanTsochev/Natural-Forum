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
                TempData[ErrorMessage] = "Error! Try again!";
                return View(model);
            }

            try
            {
                await this.articleService.CreateArticleAsync(model, User.GetId()!);

                TempData[SuccessMessage] = "House was added successfully!";
                return RedirectToAction("All", "Article");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new house! Please try again later or contact administrator!");

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            bool articleExist = await this.articleService
                .ArticleExistsByIdAsync(id);

            if (!articleExist)
            {
                TempData[ErrorMessage] = "We do not found this article! Try again, later!";

                return RedirectToAction("All", "Article");
            }

            Guid userId = Guid.Parse(User.GetId()!);

            ArticleDetailsViewModel viewModel =
                await this.articleService.GetArticleDetailsAsync(id, userId);

            viewModel.UserIsCreater = String.Equals(viewModel.CreaterId, User.GetId(),
                   StringComparison.OrdinalIgnoreCase);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool articleExist = await this.articleService
                .ArticleExistsByIdAsync(id);

            if (!articleExist)
            {
                TempData[ErrorMessage] = "We do not found this article! Try again, later!";

                return RedirectToAction("All", "Article");
            }

            ArticleDeleteViewModel viewModel =
                await this.articleService.GetArticleForDeleteAsync(id);

            viewModel.UserIsCreater = String.Equals(viewModel.CreaterId, User.GetId(),
                   StringComparison.OrdinalIgnoreCase);

            if (!viewModel.UserIsCreater)
            {
                TempData[ErrorMessage] = "You need to be article creater to delete it!";

                return RedirectToAction("All", "Article");
            }
            
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, ArticleDeleteViewModel viewModel)
        {
            bool articleExist = await this.articleService
                .ArticleExistsByIdAsync(int.Parse(id));

            if (!articleExist)
            {
                TempData[ErrorMessage] = "We do not found this article! Try again, later!";

                return RedirectToAction("All", "Article");
            }

            viewModel.UserIsCreater = String.Equals(viewModel.CreaterId, User.GetId(),
                   StringComparison.OrdinalIgnoreCase);

            if (viewModel.UserIsCreater)
            {
                TempData[ErrorMessage] = "You need to be article creater to delete it!";

                return RedirectToAction("All", "Article");
            }

            await this.articleService.DeleteArticleAsync(int.Parse(id));

            TempData[WarningMessage] = "The article was successfully deleted!";
            return RedirectToAction("All", "Article");
        }

        [HttpGet]
        public async Task<IActionResult> Like(int id)
        {
            bool articleExist = await this.articleService
                .ArticleExistsByIdAsync(id);

            if (!articleExist)
            {
                TempData[ErrorMessage] = "We do not found this article! Try again, later!";

                return RedirectToAction("All", "Article");
            }

            Guid userId = Guid.Parse(User.GetId()!);

            await this.articleService.LikeArticleSync(id, userId);

            TempData[InformationMessage] = "You liked this article!";

            return RedirectToAction("Details", "Article", new { id = id });
        }
    }
}
