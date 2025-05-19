using CleanUI;
using CleanUI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// API base URL
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7094/") });
builder.Services.AddScoped<ProductService>();

await builder.Build().RunAsync();
