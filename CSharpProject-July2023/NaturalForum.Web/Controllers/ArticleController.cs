namespace NaturalForum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Article;

    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<ArticleViewModel> viewModel = 
                await this.articleService.AllArticlesAsync();

            return View(viewModel);
        }
    }
}
