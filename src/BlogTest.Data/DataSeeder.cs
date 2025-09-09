using BlogTest.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;


namespace BlogTest.Data
{
    public class DataSeeder
    {
        public async Task SeedAsync(BlogTestContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            var rootAdminRoleId = Guid.NewGuid();
            if(!context.Roles.Any())
            {

                await context.Roles.AddAsync(new AppRole
                {
                    Id = rootAdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    DisplayName = "Quản trị viên"
                });

                await context.SaveChangesAsync();
            }
            if (!context.Users.Any())
            {
                var UserId = Guid.NewGuid();
                var user = new AppUser()
                {
                    Id = UserId,
                    FirstName = "Sy",
                    LastName = "Pham",
                    Email = "phamsy113.spm@gmail.com",
                    NormalizedEmail = "PHAMSY113.SPM@GMAIL.COM",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    IsActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    DateCreated = DateTime.Now
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");
                await context.Users.AddAsync(user);

                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>
                {
                    RoleId = rootAdminRoleId,
                    UserId = UserId
                });
                await context.SaveChangesAsync();
            }

        }
    }
}
