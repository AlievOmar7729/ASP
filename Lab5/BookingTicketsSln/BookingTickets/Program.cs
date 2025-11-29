using Microsoft.EntityFrameworkCore;
using BookingTickets.Models;
using BookingTickets.Infrastructure;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSession();

// Контекст под івенти/білети
builder.Services.AddDbContext<BookingDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:BookingTicketsConnection"]);
});

// Контекст під Identity
builder.Services.AddDbContext<AppIdentityDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:BookingTicketsConnection"]);
});

// Репозиторій для білетів
builder.Services.AddScoped<IBookingRepository, EFBookingRepository>();

// Identity з нормальним контекстом
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

// АВТОМАТИЧНЕ СТВОРЕННЯ ТАБЛИЦЬ ДЛЯ Identity
using (var scope = app.Services.CreateScope())
{
    var identityContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
    identityContext.Database.Migrate();
}

// Створити тестові дані для Events
SeedData.EnsurePopulated(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
