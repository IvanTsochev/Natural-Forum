namespace NaturalForum.Data.Models
{
	public class UserArticle
	{
		public Guid UserId { get; set; }
		public ApplicationUser User { get; set; } = null!;

		public int ArticleId { get; set; }
		public Article Article { get; set; } = null!;
	}
}
