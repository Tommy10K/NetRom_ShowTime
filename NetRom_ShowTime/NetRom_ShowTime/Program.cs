using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NetRom_ShowTime.Components;
using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Services;
using ShowTime.DataAccess;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;
using ShowTime.DataAccess.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth-token";
        options.Cookie.HttpOnly = false;
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/access-denied";
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

var connectionString = builder.Configuration.GetConnectionString("ShowTimeContext");
builder.Services.AddDbContext<ShowTimeDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IRepository<Artist>, GenericRepository<Artist>>();
builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<IRepository<Festival>, GenericRepository<Festival>>();
builder.Services.AddTransient<IFestivalService, FestivalService>();
builder.Services.AddTransient<IRepository<User>, GenericRepository<User>>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRepository<Ticket>, GenericRepository<Ticket>>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<IRepository<Booking>, GenericRepository<Booking>>();
builder.Services.AddTransient<IBookingService, BookingService>();

builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();