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
                            Description = "Размер и вес, одобренные FIFA",
                            Category = "Футбол",
                            Price = 19.50m
                        },
                        new Product
                        {
                            Name = "Угловые флаги",
                            Description = "Придайте своему игровому полю профессиональный вид",
                            Category = "Футбол",
                            Price = 34.95m
                        },
                        new Product
                        {
                            Name = "Стадион",
                            Description = "Плоский формат на 35 000 мест – профессиональный подход",
                            Category = "Футбол",
                            Price = 79500
                        },
                        new Product
                        {
                            Name = "Мыслящая шапка",
                            Description = "Повысьте эффективность мозга на 75%",
                            Category = "Шахматы",
                            Price = 16
                        },
                        new Product
                        {
                            Name = "Неустойчивый стул",
                            Description = "Тайно дайте противнику преимущество",
                            Category = "Шахматы",
                            Price = 29.95m
                        },
                        new Product
                        {
                            Name = "Человеческая шахматная доска",
                            Description = "Веселая игра для всей семьи",
                            Category = "Шахматы",
                            Price = 75
                        },
                        new Product
                        {
                            Name = "Шикарный король",
                            Description = "Позолоченный король с бриллиантами",
                            Category = "Шахматы",
                            Price = 1200
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}
