// Entry point of the whole application
var builder = WebApplication.CreateBuilder(args);

// Add services to the application
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddProblemDetails();

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