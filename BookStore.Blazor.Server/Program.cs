using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using BookStore.Blazor.Server.Components;
using BookStore.Blazor.Server.Providers;
using BookStore.Blazor.Server.Services.Authentication;
using BookStore.Blazor.Server.Services.Base;
using BookStore.Blazor.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:7295"));
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>( p => 
    p.GetRequiredService<ApiAuthenticationStateProvider>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
