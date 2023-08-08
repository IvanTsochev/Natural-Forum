namespace NaturalForum.Web.ViewModels.User
{
    public class UserServiceViewModel
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int PostCreated { get; set; }

        public bool IsAdmin { get; set; }
    }
}
