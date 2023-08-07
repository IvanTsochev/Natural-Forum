namespace NaturalForum.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using NaturalForum.Data;
    using NaturalForum.Data.Models;
    using Data.Interfaces;
    using Web.ViewModels.Tree;

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
            Tree treeToDelete = await this.dbContext
                .Trees
                .Where(a => id == a.Id)
                .FirstAsync();

            dbContext.Trees.Remove(treeToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditTreeAsync(TreeEditViewModel model)
        {
            Tree tree = await dbContext
                 .Trees
                 .FirstAsync(a => a.Id == model.Id);

            tree.Name = model.Name;
            tree.ImageUrl = model.ImageUrl;
            tree.Description = model.Description;

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

        public async Task<TreeEditViewModel> GetTreeForEditAsync(int articleId)
        {
            TreeEditViewModel tree = await this.dbContext
                .Trees
                .Where(a => a.Id == articleId)
                .Select(a => new TreeEditViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                })
                .FirstAsync();

            return tree;
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
