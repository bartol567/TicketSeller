using Microsoft.EntityFrameworkCore;
using TicketSellerAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Dodaje servise u container
builder.Services.AddControllers();
// Swagger generiranje sa potrebnom konfiguracijom
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

// HTTP request
if (app.Environment.IsDevelopment())
{
    // Swagger kao Json endpoint
    app.UseSwagger();
    // Specificira Swagger Json endpoint
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket Seller API V1");
        c.RoutePrefix = string.Empty;  
    });
}
app.UseCors("AllowAll");
// Http u Https
app.UseHttpsRedirection();
// Omoguciti autorizaciju
app.UseAuthorization();
// Controleri na njihove rute
app.MapControllers();
// Pokretanje app-a
app.Run();
