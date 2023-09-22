using CreditCardChallenge.Web;
using CreditCardChallenge.Web.Models;
using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddValidatorsFromAssemblyContaining<CardDetailsValidator>(ServiceLifetime.Transient);

await builder.Build().RunAsync();
