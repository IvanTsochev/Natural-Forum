namespace NaturalForum.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using NaturalForum.Data;
    using Data.Interfaces;
    using Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly NaturalForumDbContext dbContext;

        public UserService(NaturalForumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserProfileViewModel> GetUserProfileAsync(Guid id)
        {
            UserProfileViewModel result = await this.dbContext
                .Users
                .Include(x => x.LikedArticles)
                .ThenInclude(x => x.Article)
                .Where(u => u.Id == id)
                .Select(u => new UserProfileViewModel()
                {
                    Email = u.Email,
                    LikedArticles = u.LikedArticles
                            .Select(x => new UserProfileArticleViewModel()
                            {
                                Id = x.Article.Id,
                                Title = x.Article.Title,
                                ImageUrl = x.Article.ImageUrl,
                            }).ToList()
                })
                .FirstAsync();

            return result;
        }
    }
}
