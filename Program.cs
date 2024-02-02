using Mars_Project_1;
using Mars_Project_1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding DB context
builder.Services.AddDbContext<MarsProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Mars_Database")));


//Adding Identity DB context
//builder.Services.AddDbContext<MarsProjectIdentityDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("Mars_Database")));

//builder.Services.AddAuthorization();

//builder.Services.AddIdentityApiEndpoints<Users>()
   // .AddEntityFrameworkStores<MarsProjectIdentityDbContext>();

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapIdentityApi<Users>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
