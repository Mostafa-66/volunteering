using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Volunteering.Data;
using Volunteering.Repository;
using Volunteering.Repository.Base;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("ar-EG"),
        new CultureInfo("en-US"),
        new CultureInfo("fr")
    };

    options.DefaultRequestCulture = new RequestCulture(culture:"ar-EG", uiCulture:"ar-EG");
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
       builder.Configuration.GetConnectionString("MyConnection")
    ));

builder.Services.AddTransient(typeof(IRepository<>), typeof(MainRepository<>));

var app = builder.Build();

app.UseRequestLocalization();

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
    name: "default",
    pattern: "{controller=Opportunity}/{action=Index}/{id?}");

app.Run();
