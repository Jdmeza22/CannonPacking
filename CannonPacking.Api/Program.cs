using CannonPacking.Application.Interfaces;
using CannonPacking.Application.Services.Implementation;
using CannonPacking.Application.Services.Interfaces;
using CannonPacking.Infrastructure.Persistence;
using CannonPacking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PackingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddControllers();

builder.Services.AddScoped<ITowelService, TowelService>();
builder.Services.AddScoped<IBoxService, BoxService>();

builder.Services.AddScoped<ITowelRepository, TowelRepository>();
builder.Services.AddScoped<IBoxRepository, BoxRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAngularApp");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapControllers();

app.Run();