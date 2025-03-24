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

builder.Services.AddSingleton<ISearchService>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    string searchServiceEndpoint = config["AzureSearch:Endpoint"]!;
    string searchServiceKey = config["AzureSearch:ApiKey"]!;

    return new SearchService(searchServiceEndpoint, searchServiceKey);
});

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
