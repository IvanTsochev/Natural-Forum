namespace NaturalForum.Services.Data.Interfaces
{
    using NaturalForum.Web.ViewModels.Tree;
    public interface ITreeService
    {
        Task<IEnumerable<TreeViewModel>> AllTreesAsync();

        Task<TreeDetailsViewModel> GetTreeDetailsAsync(int id);
    }
}
