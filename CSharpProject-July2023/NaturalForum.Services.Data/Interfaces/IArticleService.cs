﻿namespace NaturalForum.Services.Data.Interfaces
{
    using NaturalForum.Web.ViewModels.Article;
    public interface IArticleService
    {
        Task<IEnumerable<ArticleViewModel>> AllArticlesAsync();
    }
}