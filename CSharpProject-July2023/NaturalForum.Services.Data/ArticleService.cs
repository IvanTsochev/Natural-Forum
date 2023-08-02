namespace NaturalForum.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using NaturalForum.Data;
    using NaturalForum.Data.Models;
    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Article;

    public class ArticleService : IArticleService
    {
        private readonly NaturalForumDbContext dbContext;

        public ArticleService(NaturalForumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ArticleViewModel>> AllArticlesAsync()
        {
            IEnumerable<ArticleViewModel> articles = await this.dbContext
                .Articles
                .Select(x => new ArticleViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Likes = x.Likes.Count(),
                    CreaterEmail = x.Creater.UserName
                })
                .ToListAsync();

            return articles;
        }

        public async Task<bool> ArticleExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
               .Articles
               .AnyAsync(a => a.Id == id);

            return result;
        }

        public async Task CreateArticleAsync(ArticleFormViewModel model, string id)
        {
            Article newArticle = new Article()
            {
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                CreaterId = Guid.Parse(id)
            };

            await this.dbContext.Articles.AddAsync(newArticle);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteArticleAsync(int id)
        {
            Article articleToDelete = await this.dbContext
                .Articles
                .Where(a => id == a.Id)
                .FirstAsync();

            dbContext.Articles.Remove(articleToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditArticleAsync(ArticleEditFormViewModel model)
        {
            Article article = await dbContext
                 .Articles
                 .FirstAsync(a => a.Id == model.Id);

            article.Title = model.Title;
            article.ImageUrl = model.ImageUrl;
            article.Description = model.Description;

            await dbContext.SaveChangesAsync();
        }

        public async Task<string> GetArticleCreaterIdAsString(int articleId)
        {
            string result = await this.dbContext
                .Articles
                .Where(x => x.Id == articleId)
                .Select(x => x.CreaterId.ToString())
                .FirstAsync();

            return result;
        }

        public async Task<ArticleDetailsViewModel> GetArticleDetailsAsync(int id, Guid userId)
        {
            ArticleDetailsViewModel result = await this.dbContext
                .Articles
                .Where(x => x.Id == id)
                .Select(x => new ArticleDetailsViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    CreaterId = x.CreaterId.ToString(),
                    CreaterEmail = x.Creater.Email,
                    ShowLikeButton = true,
                    Likes = x.Likes.Count()
                })
                .FirstAsync();

            Article? currentArticle = await this.dbContext
                    .Articles
                    .Include(a => a.Likes)
                    .Where(a => a.Id == id)
                    .FirstOrDefaultAsync();

            if (currentArticle!.Likes.Any(ua => ua.UserId == userId))
            {
                result.ShowLikeButton = false;
            }

            return result;
        }

        public async Task<ArticleDeleteViewModel> GetArticleForDeleteAsync(int id)
        {
            ArticleDeleteViewModel result = await this.dbContext
                .Articles
                .Where(x => x.Id == id)
                .Select(x => new ArticleDeleteViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    CreaterId = x.CreaterId.ToString(),
                    CreaterEmail = x.Creater.Email,
                })
                .FirstAsync();

            return result;
        }

        public async Task<ArticleEditFormViewModel> GetArticleForEditAsync(int articleId)
        {
            ArticleEditFormViewModel article = await this.dbContext
                .Articles
                .Where(a => a.Id == articleId)
                .Select(a => new ArticleEditFormViewModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                })
                .FirstAsync();

            return article;
        }

        public async Task LikeArticleAsync(int articleId, Guid userId)
        {
            Article article = await dbContext.Articles.FindAsync(articleId);
            ApplicationUser user = await dbContext.Users.FindAsync(userId);

            if (article != null && user != null)
            {
                UserArticle userArticle = new UserArticle
                {
                    UserId = user.Id,
                    User = user,
                    ArticleId = article.Id,
                    Article = article
                };

                article.Likes.Add(userArticle);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
