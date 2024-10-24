using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ResumeBlazorWASMApp;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
//using MudBlazor.Services;
using ResumeBlazorWASMApp.Pages;
using ResumeBlazorWASMApp.Services;
using Supabase;
using Supabase.Gotrue;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<CandidateService>();
//builder.Services.AddScoped<Authentication>(); //Authentication service
//builder.Services.AddMudServices();




string supabaseUrl = builder.Configuration["SupabaseUrl"];
string supabaseKey= builder.Configuration["SupabaseKey"];

//builder.Services.AddGoTrueClient(supabaseUrl, supabaseKey);

builder.Services.AddAuthorizationCore();
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
    new SupabaseService(sp.GetRequiredService<HttpClient>(), supabaseUrl));

await builder.Build().RunAsync();
