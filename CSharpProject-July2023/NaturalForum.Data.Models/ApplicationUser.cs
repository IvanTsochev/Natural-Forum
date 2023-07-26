namespace NaturalForum.Data.Models
{
	using Microsoft.AspNetCore.Identity;
	using System.ComponentModel.DataAnnotations;

	public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			this.Id = Guid.NewGuid();
			this.Articles = new HashSet<Article>();
			this.LikedArticles = new HashSet<UserArticle>();
		}

		public virtual ICollection<Article> Articles { get; set; }
		public virtual ICollection<UserArticle> LikedArticles { get; set; }
	}
}
