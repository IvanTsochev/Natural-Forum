namespace NaturalForum.Services.Data.Interfaces
{
    using NaturalForum.Web.ViewModels.Article;
    public interface IArticleService
    {
        Task<IEnumerable<ArticleViewModel>> AllArticlesAsync();

        Task CreateArticleAsync(ArticleFormViewModel model, string id);

        Task<ArticleDetailsViewModel> GetArticleDetailsAsync(int id, Guid userId);

        Task<ArticleDeleteViewModel> GetArticleForDeleteAsync(int id);

        Task<bool> ArticleExistsByIdAsync(int id);

        Task DeleteArticleAsync(int id);

        Task LikeArticleSync(int articleId, Guid userId);
    }
}
