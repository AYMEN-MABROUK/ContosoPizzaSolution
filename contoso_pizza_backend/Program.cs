using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using contoso_pizza_backend.Data;
using contoso_pizza_backend.Helpers;
using contoso_pizza_backend.Services.Interfaces;
using contoso_pizza_backend.Services.Providers;
using AutoMapper;
using NLog.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using contoso_pizza_backend.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ContosoPizzaContext>(options =>
    options.UseNpgsql(connectionString));    


builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
/*
builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
    // options.Lockout.AllowedForNewUsers = true;
    // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    // options.Lockout.MaxFailedAccessAttempts = 3;
    })
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//Token valid for 2 hours only
builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
    opt.TokenLifespan = TimeSpan.FromHours(2));

builder.Services.AddAuthorizationCore(options =>
{
options.AddPolicy(PolicyTypes.Teams.Manage, policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Teams.Manage); });
options.AddPolicy(PolicyTypes.Teams.AddRemove, policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Teams.AddRemove); });
options.AddPolicy(PolicyTypes.Users.Manage, policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Users.Add); });
options.AddPolicy(PolicyTypes.Users.EditRole, policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.Users.EditRole); });
});
*/

builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();

//*****Logging*********/
builder.Services.AddLogging(loggingBuilder =>
{
    //loggingBuilder.ClearProviders();
     loggingBuilder.AddConfiguration(builder.Configuration.GetSection("NLog"));
     loggingBuilder.AddNLog(builder.Configuration);
});
var nlogConfig = builder.Configuration.GetSection("NLog");
NLog.LogManager.Configuration = new NLogLoggingConfiguration(nlogConfig);
/***********************************/

//This is to avaoid Json loops

builder.Services.AddControllers().AddNewtonsoftJson(options =>    
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
        options.SerializerSettings.PreserveReferencesHandling =PreserveReferencesHandling.Objects ; 
    
    });

builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "CONTOSO PIZZA Backend", Version = "v1" });
        options.CustomSchemaIds(type => type.ToString());
    });
/*
//CORS all hosts
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicyAllHosts",
        builder =>
        {
            builder.SetIsOriginAllowed(origin => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    //.AllowAnyOrigin();
                    .AllowCredentials();
        });
});

//CORS with specific hosts only
var corsAllowedHosts = builder.Configuration.GetSection("CorsAllowedHosts");
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicySpecificHosts",
        builder =>
        {
            builder.SetIsOriginAllowed(origin => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    //.AllowAnyOrigin();
                    .AllowCredentials();
        });
});

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,

            ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
            ValidAudience = jwtSettings.GetSection("validAudience").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
        };
    });

builder.Services.AddScoped<JwtHandler>();
// configure DI for application services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
// builder.Services.AddScoped<IEmailSender, EmailSender>();
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "template v1"));
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "template v1"));
    builder.WebHost.UseUrls("http://0.0.0.0:7254");
}
else
{
    builder.WebHost.UseUrls("http://0.0.0.0:5001");
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.Run();

public partial class Program { }
