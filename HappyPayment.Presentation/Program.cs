using HappyPayment.Presentation.DependencyInjections;

using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.

LoggerDependencies.AddDependencies(builder.Services, builder.Configuration);
OpenTelemetryDependencies.AddDependencies(builder.Services, builder.Configuration);
SwaggerDependencies.AddDependencies(builder.Services, builder.Configuration);
MediatRDependencies.AddDependencies(builder.Services, builder.Configuration);

builder.Services.AddControllers();
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
app.UseSwagger();

app.UseEndpoints(  endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
