using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoutienScolaireV1.Shared;
using SoutienScolaireV1.Shared.Components.Pages;
using SoutienScolaireV1.Website.Components;

GlobalRenderSettings.GlobalRenderMode = Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveServer;

var builder = WebApplication.CreateBuilder(args);

var applicationDB = builder.Configuration.GetConnectionString("ApplicationDB");

Console.Out.WriteLine("Program... " + applicationDB);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

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
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(Weather).Assembly);

app.Run();
