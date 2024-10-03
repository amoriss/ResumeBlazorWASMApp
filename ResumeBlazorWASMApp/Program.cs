using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ResumeBlazorWASMApp;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using ResumeBlazorWASMApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<CandidateService>();
var configuration = builder.Configuration;
string supabaseUrl = configuration["SupabaseUrl"];
string supabaseKey= configuration["SupabaseKey"];


// builder.Services
//     .AddBlazorise(options =>
//     {
//         options.Immediate = true; // Optional: enable immediate rendering
//     })
//     .AddFontAwesomeIcons()
//     .AddBootstrapProviders(); 


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp =>
    new SupabaseService(sp.GetRequiredService<HttpClient>(), supabaseUrl, supabaseKey));
await builder.Build().RunAsync();
