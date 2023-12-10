using IotRemoteLaboratory.Components;
using IotRemoteLaboratory.Controllers;
using IotRemoteLaboratory.Interops;
using IotRemoteLaboratory.Models;
using IotRemoteLaboratory.Mqtt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Mqtt Init
builder.Services.AddSingleton(new MqttParams("test.mosquitto.org", 1883, "Hel2x"));
builder.Services.AddSingleton<MqttSubscriber>();
builder.Services.AddSingleton<MqttPublisher>();
builder.Services.AddScoped<MqttController>();

// Session
builder.Services.AddScoped<User>();
builder.Services.AddScoped<Session>();

// Session
builder.Services.AddScoped<User>();
builder.Services.AddScoped<Session>();

// Interop Init
builder.Services.AddScoped<ConsoleWrapper>();
builder.Services.AddScoped<MonacoEditorInterop>();

//Stand
builder.Services.AddSingleton<Stand>();

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
