using Microsoft.EntityFrameworkCore;
using StudyVault.Application.Interfaces;
using StudyVault.Infrastructure.Db;
using StudyVault.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

// 🔧 Register EF Core DbContext
builder.Services.AddDbContext<StudyVaultDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔧 Register services
builder.Services.AddScoped<IStudyNoteService, StudyNoteService>();

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
