using CS_MinimalApi_EF_Example.Application;
using CS_MinimalApi_EF_Example.Application.Data;
using CS_MinimalApi_EF_Example.Routes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<StudentsHandler>();
builder.Services.AddScoped<TeachersHandler>();

var app = builder.Build();
Routes.MapEndpoints(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
