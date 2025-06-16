using Microsoft.EntityFrameworkCore;
using WEB_API_V04.Data;
using WEB_API_V04.Interfaces.IRepositories;
using WEB_API_V04.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();


// <Temporarily cors> To be accessible on my localhost front-end test app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Adjust based on your frontend port
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// </Temporarily cors>


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// <Temporarily cors> To be accessible on my localhost front-end test app
app.UseCors("AllowLocalhost");
// </Temporarily cors>


app.MapControllers();

app.Run();
