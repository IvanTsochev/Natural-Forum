namespace NaturalForum.Web.ViewModels.Animal
{
    public class AnimalDetailsViewModel
    {
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public string Family { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;
	}
}
