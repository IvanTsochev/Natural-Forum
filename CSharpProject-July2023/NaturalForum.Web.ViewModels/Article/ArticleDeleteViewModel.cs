namespace NaturalForum.Web.ViewModels.Article
{
    public class ArticleDeleteViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string CreaterId { get; set; } = null!;

        public string CreaterEmail { get; set; } = null!;

        public bool UserIsCreater { get; set; }
    }
}
