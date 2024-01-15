using IotRemoteLaboratory;
using IotRemoteLaboratory.Core.Interfaces;
using IotRemoteLaboratory.Interops;
using IotRemoteLaboratory.Json.Core;
using IotRemoteLaboratory.Models;
using IotRemoteLaboratory.Mqtt.Core;
using IotRemoteLaboratory.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Mqtt Init
builder.Services.AddSingleton(
    new MqttParams("test.mosquitto.org", 1883,
        Topics.TerminalDataFrom,
        Topics.TerminalDataTo,
        Topics.LedButtonState,
        Topics.ButtonNoLedState,
        Topics.DebugCodeOutput,
        Topics.LedButtonState,
        Topics.Webcamera)
    );

builder.Services.AddSingleton<MqttSubscriber>();
builder.Services.AddSingleton<MqttPublisher>();

// Session
builder.Services.AddScoped<User>();
builder.Services.AddScoped<Session>();

builder.Services.AddSingleton(s =>
    JsonTool<IEnumerable<IStand<IMcuPlatform<ILedButton>>>>.Deserialize("N:\\VirtualStand\\Data\\stands.json").First());

// Interop Init
builder.Services.AddScoped<ConsoleWrapper>();
builder.Services.AddScoped<MonacoEditorInterop>();
builder.Services.AddScoped<JanusWebRTCInterop>();

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
