namespace NaturalForum.Data
{
	using System.Reflection;

	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using Models;
    

    public class NaturalForumDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public NaturalForumDbContext(DbContextOptions<NaturalForumDbContext> options)
			: base(options)
		{
		}

		public DbSet<Tree> Trees { get; set; } = null!;

		public DbSet<Animal> Animals { get; set; } = null!;

		public DbSet<UserArticle> UserArticles { get; set; } = null!;

		public DbSet<Article> Articles { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			Assembly configAssembly = Assembly.GetAssembly(typeof(NaturalForumDbContext)) ??
									  Assembly.GetExecutingAssembly();

			builder.ApplyConfigurationsFromAssembly(configAssembly);

			base.OnModelCreating(builder);
		}
	}
}