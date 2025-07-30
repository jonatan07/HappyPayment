using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Set Configure service variables
var serviceName = builder.Configuration["serviceName"] ?? "Payment API";
var serviceVersion = builder.Configuration["serviceName"];
var logPath = builder.Configuration["logPath"] ?? "logs/HappyPayment.log";
var zipkinHost = builder.Configuration["zipkinHost"]; 

// Configure logs
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

// Configure OpenTelemetry
builder.Services.AddOpenTelemetry()
                .WithTracing(tracerProviderBuilder =>
                {
                    tracerProviderBuilder
                        .SetResourceBuilder(ResourceBuilder.CreateDefault()
                        .AddService(serviceName: serviceName, serviceVersion: serviceVersion))
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddSource(builder.Configuration["serviceName"]?? "HappyPayment")
                        .AddZipkinExporter(zipkinOptions =>
                        {
                            zipkinOptions.Endpoint = new Uri($"{zipkinHost}/api/v2/spans"); // Zipkin local por defecto
                        });
                })
                .WithMetrics(metrics => 
                {
                    metrics
                       .AddAspNetCoreInstrumentation()
                       .AddHttpClientInstrumentation()
                       .AddPrometheusExporter();
                });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Log.Information("🔥 Serilog configurado correctamente y escribiendo en consola.");
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(  endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapPrometheusScrapingEndpoint();
});
app.Run();
