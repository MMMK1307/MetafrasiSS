using MetafrasiSS.Application;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Application.Common.Interfaces.Services;
using MetafrasiSS.Infra.DataModels.Entity;
using MetafrasiSS.Infra.Persistence;
using MetafrasiSS.Infra.Persistence.Repositories;
using MetafrasiSS.Infra.Services;
using MetafrasiSS.Infra.Common.Configuration;
using MetafrasiSS.Web.Common;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
try
{
<<<<<<< HEAD
    
=======
    builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

    builder.Services
     .AddMvc()
     .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

>>>>>>> 0edc5a0febe855b7ab6c4b39c1421b389ffee5d8
    builder.Services.AddDbContext<IdDataContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DbContextConnection"));
        options.EnableSensitiveDataLogging();
    });

    builder.Services.AddDefaultIdentity<DataUserModel>(
        options => options.SignIn.RequireConfirmedAccount = false)
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<IdDataContext>();

    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();
    builder.Services.AddAuthorization();

    // Infra
    builder.Services.AddMappings();
    builder.Services.AddScoped<IDateTimeProvider, DateTimeProvider>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
    builder.Services.AddScoped<IEmailService, EmailService>();

    builder.Services.AddApplication();

    builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SMTP"));

    var app = builder.Build();

    var supportedCultures = new[] { "en", "fr", "pt", "de", "ja", "it" };
    var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);

    app.UseRequestLocalization(localizationOptions);

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    await app.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}