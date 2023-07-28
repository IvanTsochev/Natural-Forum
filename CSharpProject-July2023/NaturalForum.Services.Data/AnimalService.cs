namespace NaturalForum.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using NaturalForum.Data;

    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Animal;
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
    }
}
