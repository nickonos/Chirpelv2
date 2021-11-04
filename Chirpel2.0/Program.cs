using Chirpel2._0_Common.Interfaces;
using Chirpel2._0_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder?.Services.AddDbContext<IChirpelContext, ChirpelContext>(options =>
{
    options.UseMySql($"server={Environment.GetEnvironmentVariable("ROKU_AUTH_IP")} ; Database=Chirpel2.0; User={ Environment.GetEnvironmentVariable("ROKU_AUTH_USERNAME")}; Password={Environment.GetEnvironmentVariable("ROKU_AUTH_PASSWORD")};", new MariaDbServerVersion(new Version(8,0,27)));
});


using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    using (var context = scope.ServiceProvider.GetService<IChirpelContext>())
    {
        context.Database.EnsureCreated();
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

app.Run();
