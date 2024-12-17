using Microsoft.EntityFrameworkCore;
using VehicleDashboardAPI.Data;

var builder = WebApplication.CreateBuilder(args);


// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()  // Allow all origins
              .AllowAnyMethod()  // Allow any HTTP method (GET, POST, etc.)
              .AllowAnyHeader(); // Allow any headers
    });
});

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Enable CORS for all origins
app.UseCors("AllowAllOrigins");
// Configure the HTTP request pipeline
app.UseHttpsRedirection();
//app.UseAuthorization();

app.UseRouting(); // Enable routing
app.MapControllers();

app.Run();

