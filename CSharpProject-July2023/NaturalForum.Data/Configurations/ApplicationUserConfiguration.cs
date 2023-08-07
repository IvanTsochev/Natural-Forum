namespace NaturalForum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(this.GenerateTrees());
        }

        private ApplicationUser[] GenerateTrees()
        {
            ICollection<ApplicationUser> applicationUsers = new HashSet<ApplicationUser>();

            ApplicationUser applicationUser;

            applicationUser = new ApplicationUser()
            {
                Id = Guid.Parse("9A8A430C-2A8D-4DF5-9A83-F200FA8DBF0D"),
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEKhnckneONR/8Hs4TdtH9yi7SGnigkeuQS7ndzz4KCF/wskc9c9/YpL+7S8kEVp/ig==",
                SecurityStamp = "L7YTGTHBFBYP7VQQRXTMPCSWIB5YWDWS",
                ConcurrencyStamp = "507a6d9f-eeae-4b49-aa62-072ab4292476",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0,
            };
            applicationUsers.Add(applicationUser);

            return applicationUsers.ToArray();
        }
    }
}
