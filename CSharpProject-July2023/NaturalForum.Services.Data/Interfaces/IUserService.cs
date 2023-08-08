namespace NaturalForum.Services.Data.Interfaces
{
    using Web.ViewModels.User;

    public interface IUserService
    {
        Task<UserProfileViewModel> GetUserProfileAsync(Guid id);

        Task<IEnumerable<UserServiceViewModel>> GetAllUsersAsync();
    }
}
