using Microsoft.EntityFrameworkCore;
using Net9ApiOdev.Data;
using Net9ApiOdev.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabaný servisini ekle (Bizim eklediðimiz kýsým)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Add services to the container.
builder.Services.AddControllers();

// Swagger / OpenAPI ayarlarý
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();