namespace NaturalForum.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using NaturalForum.Data;
    using NaturalForum.Data.Models;
    using Data.Interfaces;
    using Web.ViewModels.Animal;
    public class AnimalService : IAnimalService
    {
        private readonly NaturalForumDbContext dbContext;

        public AnimalService(NaturalForumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AnimalViewModel>> AllAnimalsAsync()
        {
            IEnumerable<AnimalViewModel> allAnimals = await this.dbContext
                .Animals
                .Select(x => new AnimalViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                })
                .ToArrayAsync();

            return allAnimals;
        }

        public async Task<bool> AnimalExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Animals
                .AnyAsync(a => a.Id == id);

            return result;
        }

        public async Task CreateAnimalAsync(AnimalFormViewModel model)
        {
            Animal newAnimal = new Animal()
            {
                Name = model.Name,
                Family = model.Family,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
            };

            await this.dbContext.Animals.AddAsync(newAnimal);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAnimalAsync(int id)
        {
            Animal animalToDelete = await this.dbContext
                .Animals
                .Where(a => id == a.Id)
                .FirstAsync();

            dbContext.Animals.Remove(animalToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditAnimalAsync(AnimalEditViewModel model)
        {
            Animal animal = await dbContext
                 .Animals
                 .FirstAsync(a => a.Id == model.Id);

            animal.Name = model.Name;
            animal.ImageUrl = model.ImageUrl;
            animal.Family = model.Family;
            animal.Description = model.Description;

            await dbContext.SaveChangesAsync();
        }

        public async Task<AnimalDetailsViewModel> GetAnimalDetailsAsync(int id)
        {
            AnimalDetailsViewModel animalDetails = await this.dbContext
                .Animals
                .Where(a => a.Id == id)
                .Select(a => new AnimalDetailsViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    ImageUrl = a.ImageUrl,
                    Description = a.Description,
                    Family = a.Family,
                })
                .FirstAsync();

            return animalDetails;
        }

        public async Task<AnimalEditViewModel> GetAnimalForEditAsync(int articleId)
        {
            AnimalEditViewModel animal = await this.dbContext
                .Animals
                .Where(a => a.Id == articleId)
                .Select(a => new AnimalEditViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Family = a.Family,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                })
                .FirstAsync();

            return animal;
        }
    }
}
