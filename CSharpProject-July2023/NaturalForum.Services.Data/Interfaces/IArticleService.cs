namespace NaturalForum.Services.Data.Interfaces
{
    using NaturalForum.Web.ViewModels.Article;
    public interface IArticleService
    {
        Task<IEnumerable<ArticleViewModel>> AllArticlesAsync();

        Task CreateArticleAsync(ArticleFormViewModel model, string id);

        Task<ArticleDetailsViewModel> GetArticleDetailsAsync(int id);
        Task<bool> ArticleExistsByIdAsync(int id);
    }
}
