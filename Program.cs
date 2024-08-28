using Microsoft.EntityFrameworkCore;
using PIM.api.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



var connectionString = builder.Configuration.GetConnectionString("FazendaCs");
var connectionStringMySql = builder.Configuration.GetConnectionString("ErpGarageCsMySql");

builder.Services.AddDbContext<FazendoDbContext>(o => o.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
