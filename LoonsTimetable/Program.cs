using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LoonsTimetable.Data;
using LoonsTimetable.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LoonsTimetableContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoonsTimetableContext") ?? throw new InvalidOperationException("Connection string 'LoonsTimetableContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(p=>p.AddPolicy("corspolicy", build => 
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();    
}));


builder.Services.AddScoped<IExamScheduleService, ExamScheduleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
