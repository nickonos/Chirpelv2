using Chirpel2._0.Middlewares;
using Chirpel2._0_Common.Interfaces;
using Chirpel2._0_Common.Interfaces.Auth;
using Chirpel2._0_Common.Interfaces.Context;
using Chirpel2._0_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder?.Services.AddDbContext<IChirpelContext, ChirpelContext>(options =>
{
    options.UseMySql($"server={Environment.GetEnvironmentVariable("ROKU_AUTH_IP")} ; Database=Chirpel2.0; User={ Environment.GetEnvironmentVariable("ROKU_AUTH_USERNAME")}; Password={Environment.GetEnvironmentVariable("ROKU_AUTH_PASSWORD")};", new MariaDbServerVersion(new Version(8,0,27)));
});
builder?.Services.AddScoped<IJWTService>(s => new JWTService(Environment.GetEnvironmentVariable("ROKU_SECRET_KEY") ?? "no valid JWT TOKEN??"));


#pragma warning disable CS8602 // Dereference of a possibly null reference.
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
#pragma warning restore CS8602 // Dereference of a possibly null reference.
{
    using (var context = scope.ServiceProvider.GetService<IChirpelContext>())
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        context.Database.EnsureCreated();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Chirpel2._0", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chirpel2._0 v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<JWTMiddleware>();
app.UseMiddleware<ExceptionHandler>();

app.Run();
