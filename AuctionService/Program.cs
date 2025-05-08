using AplicationLayer.Interfaces.Repo;
using AplicationLayer.Interfaces.Service;
using AplicationLayer.Service;
using AplicationLayer.Mapping;
using Microsoft.EntityFrameworkCore;
using PersistanceLayer;
using PersistanceLayer.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddTransient<IAuctionRepository, AuctionRepository>();
builder.Services.AddTransient<IAuctonService, AuctonService>();
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
