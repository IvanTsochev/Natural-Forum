namespace NaturalForum.Services.Tests
{
    using NUnit.Framework;

    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;

    using NaturalForum.Data;
    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Services.Data;
    using NaturalForum.Web.ViewModels.Animal;

    using static DatabaseSeeder;

    public class AnimalServiceTests
    {
        private DbContextOptions<NaturalForumDbContext> dbOptions;
        private NaturalForumDbContext dbContext;

        private IAnimalService animalService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.dbOptions = new DbContextOptionsBuilder<NaturalForumDbContext>()
                .UseInMemoryDatabase("NaturalForum" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new NaturalForumDbContext(this.dbOptions);

            this.dbContext.RemoveRange(this.dbContext.Trees);

            SeedAnimalsInDb(this.dbContext);

            this.animalService = new AnimalService(this.dbContext);
        }

        [TearDown]
        public void ResetTrees()
        {
            this.dbContext.RemoveRange(this.dbContext.Animals);

            SeedAnimalsInDb(this.dbContext);
        }

        [Test]
        public async Task AnimalExistsByIdAsyncShouldReturnTrueWhenExists()
        {
            int animalId = 1;

            bool result = await this.animalService.AnimalExistsByIdAsync(animalId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task AnimalExistsByIdAsyncShouldReturnFalseWhenDoNotExists()
        {
            int treeId = 56;

            bool result = await this.animalService.AnimalExistsByIdAsync(treeId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetAllAnimalsShoulReturnCountEqualToEntitysInDb()
        {
            int count = this.dbContext.Trees.Count();
            IEnumerable<AnimalViewModel> animals = await this.animalService.AllAnimalsAsync();

            List<AnimalViewModel> listAnimals = animals.ToList();

            bool result = listAnimals.Count == animals.Count();

            Assert.IsTrue(result);
        }

        [Test]
        public async Task EditShouldReturnTheSameEntity()
        {
            AnimalEditViewModel model = await this.animalService.GetAnimalForEditAsync(1);

            bool result = model.Name == animals.Where(x => x.Id == 1).First().Name;

            Assert.IsTrue(result);
        }

        [Test]
        public async Task EditShouldEditNameCorrectly()
        {
            AnimalEditViewModel model = await this.animalService.GetAnimalForEditAsync(2);
            model.Name = "TEST TESTOV";

            await this.animalService.EditAnimalAsync(model);

            bool result = model.Name == animals.Where(x => x.Id == 2).First().Name;

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteShouldReturnCountCorrectly()
        {
            await this.animalService.DeleteAnimalAsync(3);

            Assert.IsTrue(animals.Count() == 3);
        }

        [Test]
        public async Task CreateShoultAddOneEntity()
        {
            AnimalFormViewModel animalForm = new AnimalFormViewModel()
            {
                Name = "Test",
                Description = "test for Description a tree",
                Family = "testovo",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/74/Noyer_centenaire_en_automne.JPG/1920px-Noyer_centenaire_en_automne.JPG"
            };

            await this.animalService.CreateAnimalAsync(animalForm);

            Assert.IsTrue(this.dbContext.Animals.Count() == 4);
        }
    }
}
