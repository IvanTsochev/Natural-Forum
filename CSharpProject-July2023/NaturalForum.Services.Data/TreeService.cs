namespace NaturalForum.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using NaturalForum.Data;

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
    }
}
