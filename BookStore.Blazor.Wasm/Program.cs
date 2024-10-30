using BookStore.Blazor.Wasm;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BookStore.Blazor.Wasm.Services.Base;
using BookStore.Blazor.Wasm.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using BookStore.Blazor.Wasm.Services.Authentication;
using BookStore.Blazor.Wasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7295") });

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<ApiAuthenticationStateProvider>());

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IClient, Client>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();

await builder.Build().RunAsync();
