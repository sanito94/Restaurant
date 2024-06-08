using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Data.Models.Seed
{
    public class SeedData
    {
        public ApplicationUser AdminUser { get; set; }

        public SeedData()
        {
            SeedUsers();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new ApplicationUser()
            {
                Id = "5321f824-d6f9-4a58-beef-03b7bc3d6fa4",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Great",
                LastName = "Admin",
                Address = "ul. Pliska 4, bl. Preslav, grad Ruse",
                PostalCode = "7000",
                PhoneNumber = "+491787181664"
            };

            AdminUser.PasswordHash =
            hasher.HashPassword(AdminUser, "admin");
        }
    }
}
