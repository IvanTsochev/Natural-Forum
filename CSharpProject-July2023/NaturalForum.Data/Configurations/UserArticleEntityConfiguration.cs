namespace NaturalForum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    public class UserArticleEntityConfiguration : IEntityTypeConfiguration<UserArticle>
    {
        public void Configure(EntityTypeBuilder<UserArticle> builder)
        {
			builder
				.HasKey(ua => new { ua.UserId, ua.ArticleId });

			builder
				.HasOne(ua => ua.Article)
				.WithMany(u => u.Likes)
				.HasForeignKey(u => u.ArticleId)
				.OnDelete(DeleteBehavior.Cascade);

			builder
				.HasOne(ua => ua.User)
				.WithMany(c => c.LikedArticles)
				.HasForeignKey(au => au.UserId)
				.OnDelete(DeleteBehavior.Restrict);
		}
    }
}
