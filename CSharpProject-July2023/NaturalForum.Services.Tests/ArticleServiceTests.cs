using System.Collections.Generic;
using NaturalForum.Web.ViewModels.Article;
using NaturalForum.Web.ViewModels.Tree;

namespace NaturalForum.Services.Tests
{
    using NUnit.Framework;

    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using System.Linq;

    using NaturalForum.Data;
    using Data;
    using Data.Interfaces;

    using static DatabaseSeeder;
    public class ArticleServiceTests
    {
        private DbContextOptions<NaturalForumDbContext> dbOptions;
        private NaturalForumDbContext dbContext;

        private IArticleService articleService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.dbOptions = new DbContextOptionsBuilder<NaturalForumDbContext>()
                .UseInMemoryDatabase("NaturalForum" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new NaturalForumDbContext(this.dbOptions);

            SeedArticlesInDb(this.dbContext);

            this.articleService = new ArticleService(this.dbContext);
        }

        [TearDown]
        public void ResetArticles()
        {
            this.dbContext.Articles.RemoveRange(this.dbContext.Articles);

            SeedArticlesInDb(this.dbContext);
        }

        [Test]
        public async Task ArticleExistsByIdAsyncShouldReturnFalseWhenDoNotExist()
        {
            int articleId = 5;

            bool result = await this.articleService.ArticleExistsByIdAsync(articleId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ArticleExistsByIdAsyncShouldReturnTrueWhenDoExist()
        {
            int articleId = 50;

            bool result = await this.articleService.ArticleExistsByIdAsync(articleId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetAllArticlesShoultReturnCountEqualToEntitysInDb()
        {
            IEnumerable<ArticleViewModel> articles = await this.articleService.AllArticlesAsync();

            List<ArticleViewModel> articlesTrees = articles.ToList();

            bool result = articlesTrees.Count == this.dbContext.Articles.Count();

            Assert.IsTrue(result);
        }

        [Test]
        public async Task EditShouldReturnTheSameEntity()
        {
            ArticleEditFormViewModel model = await this.articleService.GetArticleForEditAsync(5);

            bool result = model.Title == articles.First().Title;

            Assert.IsTrue(result);
        }

        [Test]
        public async Task EditShouldEditNameCorrectly()
        {
            ArticleEditFormViewModel model = await this.articleService.GetArticleForEditAsync(5);
            model.Title = "TEST TESTOV";

            await this.articleService.EditArticleAsync(model);

            ArticleEditFormViewModel editedArticle = await this.articleService.GetArticleForEditAsync(5);

            bool result = model.Title == editedArticle.Title;

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteShouldReturnCountCorrectly()
        {
            await this.articleService.DeleteArticleAsync(5);

            Assert.IsTrue(this.dbContext.Articles.Count() == 0);
        }

        [Test]
        public async Task GetDeleteShoulReturnCorrectEntity()
        {
            ArticleDeleteViewModel article = await this.articleService.GetArticleForDeleteAsync(5);

            Assert.IsTrue(article.Title == articles.First().Title);
        }

        [Test]
        public async Task GetDetailsShoulReturnCorrectEntity()
        {
            ArticleDetailsViewModel article = await this.articleService.GetArticleDetailsAsync(5, Guid.NewGuid());

            Assert.IsTrue(article.Title == articles.First().Title);
        }

        [Test]
        public async Task CreateShoultAddOneEntity()
        {
            ArticleFormViewModel treeForm = new ArticleFormViewModel()
            {
                Title = "TEST TEST",
                Description = "test for Description a tree",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/74/Noyer_centenaire_en_automne.JPG/1920px-Noyer_centenaire_en_automne.JPG",
            };

            await this.articleService.CreateArticleAsync(treeForm, "9A8A430C-2A8D-4DF5-9A83-F200FA8DBF0D");

            Assert.IsTrue(this.dbContext.Articles.Count() == 2);
        }
    }
}
