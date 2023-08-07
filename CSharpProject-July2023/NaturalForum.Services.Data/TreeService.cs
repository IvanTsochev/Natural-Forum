namespace NaturalForum.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using NaturalForum.Data;
    using NaturalForum.Data.Models;
    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Tree;

    public class TreeService : ITreeService
    {
        private readonly NaturalForumDbContext dbContext;

        public TreeService(NaturalForumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TreeViewModel>> AllTreesAsync()
        {
            IEnumerable<TreeViewModel> allTrees = await this.dbContext
                .Trees
                .Select(t => new TreeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    ImageUrl = t.ImageUrl
                })
                .ToArrayAsync();

            return allTrees;
        }

        public async Task CreateTreeAsync(TreeFormViewModel model)
        {
            Tree newTree = new Tree()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
            };

            await this.dbContext.Trees.AddAsync(newTree);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteTreeAsync(int id)
        {
            Tree articleToDelete = await this.dbContext
                .Trees
                .Where(a => id == a.Id)
                .FirstAsync();

            dbContext.Trees.Remove(articleToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task<TreeDetailsViewModel> GetTreeDetailsAsync(int id)
        {
            TreeDetailsViewModel treeDetails = await this.dbContext
                .Trees
                .Where(t => t.Id == id)
                .Select(t => new TreeDetailsViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    ImageUrl = t.ImageUrl
                })
                .FirstAsync();

            return treeDetails;
        }

        public async Task<bool> TreeExistByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Trees
                .AnyAsync(t => t.Id == id);

            return result;
        }
    }
}
