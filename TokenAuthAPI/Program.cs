using Microsoft.EntityFrameworkCore;
using TokenAuthAPI.Models;
using TokenAuthAPI.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DigitalBookContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
builder.Services.AddTransient<IAuthenticate, Authenticate>();
builder.Services.AddSingleton<ITokenService>(new TokenService());

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
