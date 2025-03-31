using OnionAPI.Persistence;
using OnionAPI.Application;
using OnionAPI.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNpgSql();
builder.Services.AddPersistenceServices();
builder.Services.AddAutoMapper();
builder.Services.AddValidation();
builder.Services.AddMediatr();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseGlobalExceptionHandler();
app.UseElasticSeedIndexes();

app.UseAuthorization();

app.MapControllers();

app.Run();

// SABAH BUTUN HERSEYI IMPLEMENT EDIB BITIRIRIK