using BlazorServerDemo;
using BlazorServerDemo.Middleware;
using BlazorServerDemo.SmartComponents.Utils;
using DataAccess;
using DataAccess.Services;
using SmartComponents.Inference.OpenAI;
using SmartComponents.LocalEmbeddings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.RegisterDependancies();
builder.Services.AddScoped<RouteLogging>();
builder.Services.AddSmartComponents()
    .WithInferenceBackend<OpenAIInferenceBackend>();
builder.Services.AddSingleton<LocalEmbedder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    using var scope = app.Services.CreateScope();
    var users = scope.ServiceProvider.GetRequiredService<IUserService>();
    users.PopulateDbUsers();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseMiddleware<RouteLogging>();

app.UseRouting();

app.MapBlazorHub();
app.AddSmartComboboxMappings();

app.MapFallbackToPage("/_Host");

app.Run();
