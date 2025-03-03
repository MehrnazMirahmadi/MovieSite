using Microsoft.AspNetCore.Identity;
using MovieSite.IoC;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region IoC
RegisterServices(builder.Services);
#endregion

#region DB
string ConnectionString = builder.Configuration["ConnectionString:MovieDbConnection"].ToString();
string SecurityConnection = builder.Configuration["ConnectionString:SecurityConnectionString"].ToString();
MovieSite.BootStrap.BootStrap.WireUP(builder.Services, ConnectionString, SecurityConnection);
#endregion

#region Identity
// Configure Identity
builder.Services.AddIdentity<Security.ApplicationUser, Security.ApplicationRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
})
.AddEntityFrameworkStores<Security.SecurityContext>()
.AddDefaultTokenProviders();

// Configure Authentication cookie for Forms Authentication
builder.Services.ConfigureApplicationCookie(options =>
{

    options.Cookie.Name = ".MyAuthCookie";// ‰«„ òÊò?
    options.Cookie.HttpOnly = true; // òÊò? ›ﬁÿ »—«? HTTP «” 
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // „œ  “„«‰ «‰ﬁ÷«
    options.SlidingExpiration = true; //  „œ?œ “„«‰ «‰ﬁ÷« »Â ’Ê—  ŒÊœò«—
    options.LoginPath = "/Account/Login"; // „”?— ’›ÕÂ Ê—Êœ
    options.LogoutPath = "/Account/Logout"; // „”?— ’›ÕÂ Œ—ÊÃ
    options.AccessDeniedPath = "/Account/AccessDenied"; // „”?— œ” —”? „„‰Ê⁄
});
#endregion
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

#region Register service method
static void RegisterServices(IServiceCollection services)
{
    DependencyContainers.RegisterServices(services);
}
#endregion