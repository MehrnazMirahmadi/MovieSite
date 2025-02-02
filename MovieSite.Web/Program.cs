using MovieSite.IoC;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region IoC
RegisterServices(builder.Services);
#endregion

#region DB
string ConnectionString = builder.Configuration["ConnectionString:MovieDbConnection"].ToString();
MovieSite.BootStrap.BootStrap.WireUP(builder.Services, ConnectionString); 
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