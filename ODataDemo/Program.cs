using ODataDemo;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ODataDemo.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ODataDemoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ODataDemoContext") ?? throw new InvalidOperationException("Connection string 'ODataDemoContext' not found.")));

// Add services to the container.

builder.Services.AddControllers().AddOData(options => options.Select().Filter());
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
