namespace NaturalForum.Web.ViewModels.User
{
    public class UserProfileViewModel
    {
        public UserProfileViewModel()
        {
            this.LikedArticles = new HashSet<UserProfileArticleViewModel>();
        }

        public string Email { get; set; } = null!;

        public IEnumerable<UserProfileArticleViewModel> LikedArticles { get; set; }
    }
}
