using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIDemo.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using APIDemo.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APIDemoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIDemoContext") ?? throw new InvalidOperationException("Connection string 'APIDemoContext' not found.")));

builder.Services.AddControllers().AddOData(options => options.Select().Filter());

builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
// requires using Microsoft.AspNet.OData.Extensions;
//builder.Services.AddOData();
//public void ConfigureServices(IServiceCollection services)
//{
//    services.AddDbContext<APIDemoContext>(opt =>
//        opt.UseInMemoryDatabase("TodoList"));
//    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
//    // requires using Microsoft.AspNet.OData.Extensions;
//    services.AddOData();
//}
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
});


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
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
