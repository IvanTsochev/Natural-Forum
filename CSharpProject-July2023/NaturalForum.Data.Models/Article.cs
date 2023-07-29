namespace NaturalForum.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using static Common.EntityValidationConstants.Article;
	public class Article
	{
		public Article()
		{
			this.Likes = new HashSet<UserArticle>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		[MaxLength(ImageUrlMaxLenght)]
		public string ImageUrl { get; set; } = null!;

		[ForeignKey("Creater")]
		public Guid CreaterId { get; set; }
		public virtual ApplicationUser Creater { get; set; } = null!;

		public virtual ICollection<UserArticle> Likes { get; set; }
	}
}
