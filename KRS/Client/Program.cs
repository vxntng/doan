using BusinessObjects.Models;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("JustBlogContextConnection");
builder.Services.AddDbContext<KRSDbContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
// Đăng ký HttpClient
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapGet("/", async context =>
{
    context.Response.Redirect("/login");
});
app.MapControllerRoute(
    name: "accountIndex",
    pattern: "Account/Index",
    defaults: new { controller = "Account", action = "Index" });
app.Run();
