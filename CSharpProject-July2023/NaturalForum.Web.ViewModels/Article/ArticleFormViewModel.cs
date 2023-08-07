namespace NaturalForum.Web.ViewModels.Article
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Article;
	public class ArticleFormViewModel
    {
		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string Description { get; set; } = null!;

		[Required]
		[StringLength(ImageUrlMaxLenght)]
		public string ImageUrl { get; set; } = null!;
	}
}
