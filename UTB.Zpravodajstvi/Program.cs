using Microsoft.EntityFrameworkCore;
using UTB.Zpravodajstvi.Infrastructure.Database;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.Implementation;
using Microsoft.AspNetCore.Identity;
using UTB.Zpravodajstvi.Infrastructure.Identity;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.40");
builder.Services.AddDbContext<ZpravodajstviDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));

//Configuration for Identity
builder.Services.AddIdentity<User, Role>()
     .AddEntityFrameworkStores<ZpravodajstviDbContext>()
     .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Security/Account/Login";
    options.LogoutPath = "/Security/Account/Logout";
    options.SlidingExpiration = true;
});

//registrace slu�eb aplika�n� vrstvy
builder.Services.AddScoped<IFileUploadService, FileUploadService>(serviceProvider => new FileUploadService(serviceProvider.GetService<IWebHostEnvironment>().WebRootPath));
builder.Services.AddScoped<IArticleAppService, ArticleAppService>();
builder.Services.AddScoped<ICarouselAppService, CarouselAppService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IAccountService, AccountIdentityService>();
builder.Services.AddScoped<ISecurityService, SecurityIdentityService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console(
        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("logs/zpravodajstvi-.txt", 
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

if (!Directory.Exists("logs"))
{
    Directory.CreateDirectory("logs");
}

try
{
    Log.Information("Aplikace se spouští...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Aplikace neočekávaně skončila");
}
finally
{
    Log.CloseAndFlush();
}
