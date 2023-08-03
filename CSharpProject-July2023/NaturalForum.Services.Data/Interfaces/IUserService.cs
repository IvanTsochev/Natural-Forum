using NaturalForum.Web.ViewModels.User;

namespace NaturalForum.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<UserProfileViewModel> GetUserProfileAsync(Guid id);
    }
}
