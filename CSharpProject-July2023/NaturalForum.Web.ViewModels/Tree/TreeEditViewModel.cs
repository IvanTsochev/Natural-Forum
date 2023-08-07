namespace NaturalForum.Web.ViewModels.Tree
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Tree;

	public class TreeEditViewModel
    {
        public int Id { get; set; }

        [Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		[MaxLength(ImageUrlMaxLenght)]
		public string ImageUrl { get; set; } = null!;
	}
}
