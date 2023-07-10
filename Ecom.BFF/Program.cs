using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.BFF.Core.Models;
using WebApp.BFF.Database;

var builder = WebApplication.CreateBuilder(args);

#region Dependency Injections


#endregion

#region Database - Identity Configurations
builder.Services.AddDbContext<EcomContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("EcomContext")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<EcomContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "ChatiusCokie";
});

#endregion

#region Services
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((host) => true)
                   .AllowCredentials();
        }));
var app = builder.Build();

#endregion

#region Middlewares Pipeline

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapDefaultControllerRoute();
//    endpoints.MapHub<ChatHub>("/hub", options =>
//    {
//        options.Transports =
//               HttpTransportType.WebSockets |
//               HttpTransportType.LongPolling;
//    });

//});

app.MapDefaultControllerRoute();

try
{
    app.Run();
}
catch (Exception)
{
    throw;
}
#endregion