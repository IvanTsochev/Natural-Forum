namespace NaturalForum.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Animal;

	public class Animal
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		[MaxLength(FamilyNameMaxLength)]
		public string Family { get; set; } = null!;

		[Required]
		[MaxLength(ImageUrlMaxLenght)]
		public string ImageUrl { get; set; } = null!;
	}
}
