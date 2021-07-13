namespace CarRentingSystem.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    using Data;
    using Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var db = scopedServices.ServiceProvider.GetService<ApplicationDbContext>();

            db.Database.Migrate();

            SeedCategories(db);

            return app;
        }

        private static void SeedCategories(ApplicationDbContext db)
        {
            if (db.Categories.Any())
            {
                return;
            }

            db.Categories.AddRange(new[]
            {
                new Category() { Name = "Mini" },
                new Category() { Name = "Economy" },
                new Category() { Name = "Midsize" },
                new Category() { Name = "Large" },
                new Category() { Name = "SUV" },
                new Category() { Name = "Vans" },
                new Category() { Name = "Luxury" },
            });

            db.SaveChanges();
        }
    }
}
