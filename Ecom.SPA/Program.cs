var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSpaStaticFiles(config =>
{
    config.RootPath = "ClientApp/dist";
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSpa(client =>
{
    client.UseProxyToSpaDevelopmentServer("https://localhost:5000");
});

app.Run();