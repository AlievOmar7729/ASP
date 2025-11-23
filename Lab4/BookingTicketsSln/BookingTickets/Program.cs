using Microsoft.EntityFrameworkCore;
using BookingTickets.Models;
using BookingTickets.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSession();


builder.Services.AddDbContext<BookingDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:BookingTicketsConnection"]);
});


builder.Services.AddScoped<IBookingRepository, EFBookingRepository>();

var app = builder.Build();



app.UseSession();
app.MapDefaultControllerRoute();
app.UseStaticFiles();


SeedData.EnsurePopulated(app);

app.Run();
