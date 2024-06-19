using MetafrasiSS.Application;
using MetafrasiSS.Application.Common.Interfaces.Persistence;
using MetafrasiSS.Application.Common.Interfaces.Services;
using MetafrasiSS.Web.Common;
using MetafrasiSS.Infra.DataModels.Entity;
using MetafrasiSS.Infra.Persistence;
using MetafrasiSS.Infra.Persistence.Repositories;
using MetafrasiSS.Infra.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
try
{
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

	//Infra
	builder.Services.AddMappings();
	builder.Services.AddScoped<IDateTimeProvider, DateTimeProvider>();
	builder.Services.AddScoped<IUserRepository, UserRepository>();
	builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

	builder.Services.AddApplication();

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
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");

	app.Run();
}
catch (Exception)
{
}