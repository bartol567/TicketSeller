using Microsoft.EntityFrameworkCore;
using TicketSellerAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Add Swagger generation with the necessary configurations.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<TicketSellerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TicketSellerDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket Seller API V1");
        c.RoutePrefix = string.Empty;  // Serve the Swagger UI at the app's root (e.g., http://localhost:5000/)
    });
}
app.UseCors("AllowAll");
// Middleware to redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();
// Middleware to enable authorization.
app.UseAuthorization();
// Maps controllers to their respective routes.
app.MapControllers();
// Runs the application.
app.Run();
