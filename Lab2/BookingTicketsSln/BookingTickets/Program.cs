using Microsoft.EntityFrameworkCore;
using BookingTickets.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookingDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:BookingTicketsConnection"]);
});


builder.Services.AddScoped<IBookingRepository, EFBookingRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
