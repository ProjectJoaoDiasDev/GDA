using GDA.Data.Contexts;
using GDA.Di;
using GDA.Domain.Interfaces;
using GDA.Web.Filters;
using GDA.Web.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(config =>
{
    config.Filters.Add(typeof(CustomExceptionFilter));
    config.ModelBinderProviders.Insert(0, new DecimalBindModel());
});

DependencyInjection.Configure(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddEndpointsApiExplorer();

builder.WebHost.UseUrls("http://localhost:7771,https://localhost:7772");

var app = builder.Build();

app.Use(async (context, next) =>
{

    await next.Invoke();
    var unitOfWork = context.RequestServices.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
    if (unitOfWork is not null)
    {
        await unitOfWork.Commit();
    }
});

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    if (context?.Database.GetPendingMigrations()?.Count() > 0)
    {
        context.Database.Migrate();
    }
}

app.Run();
