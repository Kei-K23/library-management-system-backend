// Entry point of the whole application
using LibraryManagementSystemBackend.ApplicationDBContext;
using LibraryManagementSystemBackend.Interfaces;
using LibraryManagementSystemBackend.Models;
using LibraryManagementSystemBackend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the application
// DB setup
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddProblemDetails();
builder.Services.AddScoped<IUserService<User>, UserService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add Dependency Injection services
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    // If app is run in development, use swagger for API documentation
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Run the app
app.Run();