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

        public Category Starters { get; set; }
        public Category Breakfast { get; set; }
        public Category Lunch { get; set; }
        public Category Dinner { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedStarters();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new ApplicationUser()
            {
                Id = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Great",
                LastName = "Admin"
            };

            AdminUser.PasswordHash =
            hasher.HashPassword(AdminUser, "admin");
        }

        private void SeedStarters()
        {
            Starters = new Category()
            {
                Id = 1,
                Name = "Starters"
            };

            Breakfast = new Category()
            {
                Id = 2,
                Name = "Breakfast"
            };

            Lunch = new Category()
            {
                Id = 3,
                Name = "Lunch"
            };

            Dinner = new Category()
            {
                Id = 4,
                Name = "Dinner"
            };
        }
    }
}
