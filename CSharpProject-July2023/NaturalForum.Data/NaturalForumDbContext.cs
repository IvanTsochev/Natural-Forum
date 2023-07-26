namespace NaturalForum.Data
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using NaturalForum.Data.Models;

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
			builder.Entity<UserArticle>()
				.HasKey(ua => new { ua.UserId, ua.ArticleId });

			builder.Entity<UserArticle>()
				.HasOne(ua => ua.Article)
				.WithMany(u => u.Likes)
				.HasForeignKey(u => u.ArticleId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<UserArticle>()
				.HasOne(ua => ua.User)
				.WithMany(c => c.LikedArticles)
				.HasForeignKey(au => au.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(builder);
		}
	}
}