namespace NaturalForum.Common
{
	public static class EntityValidationConstants
	{
		public static class CategoryTree
		{
			public const int NameMinLength = 2;		
			public const int NameMaxLength = 15;		
		}

		public static class Tree
		{
			public const int NameMinLength = 2;
			public const int NameMaxLength = 50;

			public const int ImageUrlMaxLenght = 2048;

			public const int DescriptionMinLength = 15;
			public const int DescriptionMaxLength = 500;
		}

		public static class Animal
		{
			public const int NameMinLength = 2;
			public const int NameMaxLength = 50;

			public const int ImageUrlMaxLenght = 2048;

			public const int FamilyNameMinLength = 2;
			public const int FamilyNameMaxLength = 20;

			public const int DescriptionMinLength = 20;
			public const int DescriptionMaxLength = 600;
		}

		public static class Article
		{
			public const int TitleMinLength = 4;
			public const int TitleMaxLength = 50;

			public const int ImageUrlMaxLenght = 2048;

			public const int DescriptionMinLength = 20;
			public const int DescriptionMaxLength = 600;
		}
	}
}
