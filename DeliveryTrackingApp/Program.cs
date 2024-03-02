using DeliveryTrackingApp.Data;
using DeliveryTrackingApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Minio;


var builder = WebApplication.CreateBuilder(args);
//use json config and env variables for configuration
builder.Configuration.AddJsonFile("appsettings.json").AddEnvironmentVariables();
// Add services to the container.
builder.Services.AddControllersWithViews();
//initialize default database connection
builder.Services.AddDbContext<DefaultDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDb")));
//initialize minio;
initMinio(builder.Services, builder.Configuration);
//initialize unit of work
initUnitOfWork(builder.Services);
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

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
    
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static void initUnitOfWork(IServiceCollection services){
    services.AddScoped<IUnitOfWork, UnitOfWork>();
}
static void initMinio(IServiceCollection services, ConfigurationManager configuration ){
    var minioConfig = configuration.GetSection("Minio");
    var minioAccessKey = minioConfig.GetValue<string>("AccessKey", "");
    var minioSecretKey = minioConfig.GetValue<string>("SecretKey", "");
    var endpoint = minioConfig.GetValue<string>("Endpoint", "");
    services.AddMinio(client=> client.WithCredentials(minioAccessKey, minioSecretKey).WithEndpoint(endpoint));
}