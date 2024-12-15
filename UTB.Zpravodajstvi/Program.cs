using Microsoft.EntityFrameworkCore;
using UTB.Zpravodajstvi.Infrastructure.Database;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.40");
builder.Services.AddDbContext<ZpravodajstviDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));

//registrace služeb aplikaèní vrstvy
builder.Services.AddScoped<IArticleAppService, ArticleAppService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
