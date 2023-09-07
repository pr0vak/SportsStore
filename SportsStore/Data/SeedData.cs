using Microsoft.EntityFrameworkCore;
using SportsStore.Contexts;
using SportsStore.Models;

namespace SportsStore.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                        new Product
                        {
                            Name = "Каяк",
                            Description = "Лодка для одного человека",
                            Category = "Водный спорт",
                            Price = 275
                        },
                        new Product
                        {
                            Name = "Спасательный жилет",
                            Description = "Защитный и модный",
                            Category = "Водный спорт",
                            Price = 48.95m
                        },
                        new Product
                        {
                            Name = "Футбольный мяч",
                            Description = "Размер и вес, одобренные FIFA.",
                            Category = "Футбол",
                            Price = 19.50m
                        },
                        new Product
                        {
                            Name = "Угловые флаги",
                            Description = "Придайте своему игровому полю профессиональный вид",
                            Category = "Футбол",
                            Price = 34.95m
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}
