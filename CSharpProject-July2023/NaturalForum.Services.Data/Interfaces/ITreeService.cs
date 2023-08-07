﻿namespace NaturalForum.Services.Data.Interfaces
{
    using NaturalForum.Web.ViewModels.Tree;
    public interface ITreeService
    {
        Task<IEnumerable<TreeViewModel>> AllTreesAsync();

        Task<TreeDetailsViewModel> GetTreeDetailsAsync(int id);

        Task<bool> TreeExistByIdAsync(int id);

        Task CreateTreeAsync(TreeFormViewModel model);

        Task DeleteTreeAsync(int id);
    }
}
