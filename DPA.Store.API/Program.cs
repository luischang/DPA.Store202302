using DPA.Store.DOMAIN.Core.Interfaces;
using DPA.Store.DOMAIN.Core.Services;
using DPA.Store.DOMAIN.Infrastructure.Data;
using DPA.Store.DOMAIN.Infrastructure.Repositories;
using DPA.Store.DOMAIN.Infrastructure.Shared;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var _cnx = _config.GetConnectionString("DevConnection");
builder
    .Services
    .AddDbContext<StoreDbContext>(options =>
    {
        options.UseSqlServer(_cnx);
    });

builder
    .Services
    .AddTransient<ICategoryRepository, CategoryRepository>();
builder
    .Services
    .AddTransient<IUserRepository, UserRepository>();
builder
    .Services
    .AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();


builder.Services.AddSharedInfrastructure(_config);


builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
                
    });
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

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
