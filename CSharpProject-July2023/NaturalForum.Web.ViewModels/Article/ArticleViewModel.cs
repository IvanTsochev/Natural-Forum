namespace NaturalForum.Web.ViewModels.Article
{
    public class ArticleViewModel
    {
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

        public string CreaterEmail { get; set; } = null!;

        public int Likes { get; set; }
    }
}
