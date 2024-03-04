using DeliveryTrackingApp.Data;
using DeliveryTrackingApp.Repositories;
using DeliveryTrackingApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Minio;
using Minio.DataModel.Args;


var builder = WebApplication.CreateBuilder(args);
//Use json config and env variables for configuration
builder.Configuration.AddJsonFile("appsettings.json").AddEnvironmentVariables();
// Add services to the container.
builder.Services.AddControllersWithViews();
//Initialize default database connection
builder.Services.AddDbContext<DefaultDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDb")));
//Initialize minio;
initMinio(builder.Services, builder.Configuration);
//Initialize unit of work
initUnitOfWork(builder.Services);
var app = builder.Build();
//Create bucket and policy
MinioServiceBootstrap.Initialize(app.Services.GetRequiredService<IMinioClient>(), builder.Configuration);

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
    var minioConfig =  configuration.GetSection("Minio");
    var minioAccessKey = minioConfig.GetValue<string>("AccessKey", "");
    var minioSecretKey = minioConfig.GetValue<string>("SecretKey", "");
    var endpoint = minioConfig.GetValue<string>("Endpoint", "");
    if(minioAccessKey.IsNullOrEmpty()){
        throw new Exception("Minio access key is required.");
    }
    if(minioSecretKey.IsNullOrEmpty()){
        throw new Exception("Minio secret key is required.");
    }
    if(endpoint.IsNullOrEmpty()){
        throw new Exception("Minio endpoint is required.");
    }
    services.AddMinio(client=> client.WithCredentials(minioAccessKey, minioSecretKey).WithEndpoint(endpoint).WithSSL(false));
}
