using LivrariaMud.CrossCutting.DependenciesApp;
using LivrariaMud.Web.Components;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbApp( builder.Configuration );

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Front lib
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddServiceApp();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( !app.Environment.IsDevelopment() )
{
    app.UseExceptionHandler( "/Error", createScopeForErrors: true );
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
