using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.Binders.CalculationBinders;
using StructuredCablingStudio.Contexts;
using StructuredCablingStudio.Entities;
using StructuredCablingStudio.Filters.LocalizationFilters;
using StructuredCablingStudio.Interceptors;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(opt =>
{
	opt.ModelBinderProviders.Insert(0, new StructuredCablingStudioParametersModelBinderProvider());
	opt.ModelBinderProviders.Insert(0, new ConfigurationCalculateParametersModelBinderProvider());
	opt.ModelBinderProviders.Insert(0, new CalculateDTOModelBinderProvider());
})
	.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
	.AddDataAnnotationsLocalization();

builder.Services.AddHttpContextAccessor();

builder.Services.AddIdentity<User, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddScoped<ConfigureSessionContextInterceptor>()
	.AddScoped<SetLocalizationCookiesFilterAttribute>()
	.AddDbContext<ApplicationContext>((sp, opt) =>
	{
		opt.UseSqlServer(builder.Configuration.GetConnectionString("CablingConfigurationsDB"))
		.AddInterceptors(sp.GetRequiredService<ConfigureSessionContextInterceptor>());
	})
	.AddLocalization(opt => opt.ResourcesPath = "Resources")
	.Configure<RequestLocalizationOptions>(opt =>
	{
		var supportedCultures = new[]
		{
			new CultureInfo("ru"),
			new CultureInfo("en"),
			new CultureInfo("uk")
		};
		opt.DefaultRequestCulture = new RequestCulture("en");
		opt.SupportedCultures = supportedCultures;
		opt.SupportedUICultures = supportedCultures;
	})
	.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRequestLocalization();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Calculation}/{action=Calculate}/{id?}");

app.Run();
