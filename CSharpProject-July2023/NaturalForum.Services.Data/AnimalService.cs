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
    }
}
