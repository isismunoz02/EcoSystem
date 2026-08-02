using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EcoSystem.Client;
using EcoSystem.Client.Services;
using EcoSystem.Client.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5042/"),
    Timeout = TimeSpan.FromSeconds(15)
});
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<LoginViewModel>();

await builder.Build().RunAsync();