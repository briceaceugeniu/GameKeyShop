global using GameKeyShop.Shared.Models;
global using GameKeyShop.Shared.DTO;
global using System.Net.Http.Json;
global using GameKeyShop.Client.Services.ProductService;
global using GameKeyShop.Client.Services.CategoryService;
global using GameKeyShop.Client.Services.CartService;
global using GameKeyShop.Client.Services.AuthService;
global using Microsoft.AspNetCore.Components.Authorization;
global using GameKeyShop.Client.Services.OrderService;
global using GameKeyShop.Client.Services.AddressService;
global using GameKeyShop.Client.Services.DeveloperService;
global using GameKeyShop.Client.Services.PlatformTypeService;
using GameKeyShop.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IDeveloperService, DeveloperService>();
builder.Services.AddScoped<IPlatformTypeService, PlatformTypeService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
