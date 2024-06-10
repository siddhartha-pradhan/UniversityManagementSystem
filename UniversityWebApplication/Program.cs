using Microsoft.EntityFrameworkCore;
using UniversityWebApplication.Data;
using UniversityWebApplication.Repositories.Base;
using UniversityWebApplication.Services;
using UniversityWebApplication.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configurations = builder.Configuration;

var connectionString = configurations.GetConnectionString("DefaultConnection");

services.AddControllers();

services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

services.AddTransient<IUnitOfWork, UnitOfWork>();

services.AddTransient<IQueryService, QueryService>();

services.AddAutoMapper(typeof(Program).Assembly);

services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
