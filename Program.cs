using FastDesafio.Data;
using FastDesafio.Interfaces;
using FastDesafio.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();

builder.Services.AddScoped<IWorkshopInterface, WorkshopService>();
builder.Services.AddScoped<ICollaboratorInterface, CollaboratorService>();
builder.Services.AddScoped<IRecordInterface, RecordService>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(cors =>
{
    cors.AllowAnyOrigin();
    cors.AllowAnyMethod();
    cors.AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
