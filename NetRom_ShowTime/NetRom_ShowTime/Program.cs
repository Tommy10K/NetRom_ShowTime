using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NetRom_ShowTime.Components;
using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.BusinessLogic.Services;
using ShowTime.DataAccess;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;
using ShowTime.DataAccess.Repositories.Implementations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddRazorComponents()
.AddInteractiveServerComponents()
.AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth-token";
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/access-denied";
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

var  connectionString = builder.Configuration.GetConnectionString("ShowTimeContext");
builder.Services.AddDbContext<ShowTimeDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IRepository<Artist>, GenericRepository<Artist>>();
builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<IRepository<Festival>, GenericRepository<Festival>>();
builder.Services.AddTransient<IFestivalService, FestivalService>();
builder.Services.AddTransient<IRepository<User>, GenericRepository<User>>();
builder.Services.AddTransient<IUserService, UserService>();

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
app.UseRouting();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/api/login", async (
      LogInDto dto,
      IUserService userService,
      HttpContext http
    ) =>
{
    var user = await userService.LogInAsync(dto);
    if (user == null)
        return Results.Unauthorized();

    var claims = new[]
    {
      new Claim(ClaimTypes.Email, user.Email),
      new Claim(ClaimTypes.Role,  user.Role.ToString())
    };
    var principal = new ClaimsPrincipal(
       new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

    await http.SignInAsync(
      CookieAuthenticationDefaults.AuthenticationScheme,
      principal,
      new AuthenticationProperties { IsPersistent = true });

    return Results.Ok();
});

app.MapRazorPages();
app.MapRazorComponents<App>()
.AddInteractiveServerRenderMode();

app.MapFallbackToFile("index.html");

app.Run();
