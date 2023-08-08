namespace NaturalForum.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using NaturalForum.Data;
    using Data.Interfaces;
    using Web.ViewModels.User;
    using System.Collections.Generic;
    using NaturalForum.Data.Models;

    using static Common.GeneralApplicationConstants;

    public class UserService : IUserService
    {
        private readonly NaturalForumDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(NaturalForumDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<UserServiceViewModel>> GetAllUsersAsync()
        {
            IEnumerable<UserServiceViewModel> users = await this.dbContext
                .Users
                .Select(x => new UserServiceViewModel()
                {
                    Id = x.Id.ToString(),
                    Email = x.Email,
                    PostCreated = x.Articles.Count,
                })
                .ToListAsync();

            foreach (var user in users)
            {
                ApplicationUser applicationUser = await userManager.FindByIdAsync(user.Id);

                user.IsAdmin = await this.userManager
                    .IsInRoleAsync(applicationUser, AdminRoleName);
            }

            return users;
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
