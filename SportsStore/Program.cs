using Microsoft.EntityFrameworkCore;
using SportsStore.Contexts;
using SportsStore.Data;
using SportsStore.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}");

SeedData.EnsurePopulated(app);

app.Run();
