namespace NaturalForum.Services.Tests
{
    using NUnit.Framework;

    using System;
    using Microsoft.EntityFrameworkCore;

    using NaturalForum.Data;
    using Data.Interfaces;
    using Data;

    using static DatabaseSeeder;
    using System.Threading.Tasks;
    using Web.ViewModels.Tree;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeServiceTests
    {
        private DbContextOptions<NaturalForumDbContext> dbOptions;
        private NaturalForumDbContext dbContext;

        private ITreeService treeService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.dbOptions = new DbContextOptionsBuilder<NaturalForumDbContext>()
                .UseInMemoryDatabase("NaturalForum" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new NaturalForumDbContext(this.dbOptions);

            this.dbContext.RemoveRange(this.dbContext.Trees);

            SeedTreesInDb(this.dbContext);

            this.treeService = new TreeService(this.dbContext);
        }

        [TearDown]
        public void ResetTrees()
        {
            this.dbContext.RemoveRange(this.dbContext.Trees);

            SeedTreesInDb(this.dbContext);
        }

        [Test]
        public async Task TreeExistsByIdAsyncShouldReturnTrueWhenExists()
        {
            int treeId = 1;

            bool result = await this.treeService.TreeExistByIdAsync(treeId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task TreeExistsByIdAsyncShouldReturnFalseWhenDoNotExists()
        {
            int treeId = 56;

            bool result = await this.treeService.TreeExistByIdAsync(treeId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetAllTreesShouldReturnCountEqualToEntitiesInDb()
        {
            IEnumerable<TreeViewModel> trees = await this.treeService.AllTreesAsync();

            List<TreeViewModel> listTrees = trees.ToList();

            bool result = listTrees.Count == this.dbContext.Trees.Count();

            Assert.IsTrue(result);
        }

        [Test]
        public async Task EditShouldReturnTheSameEntity()
        {
            TreeEditViewModel model = await this.treeService.GetTreeForEditAsync(2);

            bool result =  model.Name == trees.Where(x => x.Id == 2).First().Name;

            Assert.IsTrue(result);
        }

        [Test]
        public async Task EditShouldEditNameCorrectly()
        {
            TreeEditViewModel model = await this.treeService.GetTreeForEditAsync(1);
            model.Name = "TEST TESTOV";

            await this.treeService.EditTreeAsync(model);

            bool result = model.Name == trees.First().Name;

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteShouldReturnCountCorrectly()
        {
            await this.treeService.DeleteTreeAsync(3);

            Assert.IsTrue(this.dbContext.Trees.Count() == 2);
        }

        [Test]
        public async Task CreateShouldAddOneEntity()
        {
            TreeFormViewModel treeForm = new TreeFormViewModel()
            {
                Name = "Test",
                Description = "test for Description a tree",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/74/Noyer_centenaire_en_automne.JPG/1920px-Noyer_centenaire_en_automne.JPG"
            };

            await this.treeService.CreateTreeAsync(treeForm);

            Assert.IsTrue(this.dbContext.Trees.Count() == 4);
        }

        [Test]
        public async Task GetDetailsShouldReturnCorrectEntity()
        {
            TreeDetailsViewModel article = await this.treeService.GetTreeDetailsAsync(1);

            Assert.IsTrue(article.Name == trees.First().Name);
        }
    }
}