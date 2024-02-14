using Contact_Manager_Application.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add core dependency injection
builder.Services.AddDbContext<ContactContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ContactContext")));

//setting the url to be lowercase
builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Shared/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Setting the pattern for endpoints to use by default
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Contact}/{action=Index}/{id?}/{slug?}");
});

app.Run();