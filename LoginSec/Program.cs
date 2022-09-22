using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LoginSec.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("OnlineConnect") ?? throw new InvalidOperationException("Connection string 'IdentityApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<IdentityApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Auhtorisation
AddAuthorisationPolicies(builder.Services);
#endregion

//Db data
builder.Services.AddDbContext<IdentityApplicationDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("OnlineConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("OnlineData")));


//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2VVhiQlFaclxJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdk1iWn5ac3VVRWVdUUU=");



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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

void AddAuthorisationPolicies(IServiceCollection services)
{
    
   services.AddAuthorization(options =>
    {
   options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
   });
}
