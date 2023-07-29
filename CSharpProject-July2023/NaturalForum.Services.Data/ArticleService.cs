﻿namespace NaturalForum.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using NaturalForum.Data;
    using NaturalForum.Services.Data.Interfaces;
    using NaturalForum.Web.ViewModels.Article;
    public class ArticleService : IArticleService
    {
        private readonly NaturalForumDbContext dbContext;

        public ArticleService(NaturalForumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ArticleViewModel>> AllArticlesAsync()
        {
            IEnumerable<ArticleViewModel> articles = await this.dbContext
                .Articles
                .Select(x => new ArticleViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Likes = x.Likes.Count(),
                    CreaterEmail = x.Creater.UserName
                })
                .ToListAsync();

            return articles;
        }
    }
}