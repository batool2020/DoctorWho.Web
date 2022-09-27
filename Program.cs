using DoctorWho.Db;
using DoctorWho.Web.Services;
using DoctorWho.Web.Validators;
using episodeWho.Web.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddValidatorsFromAssemblyContaining<DoctorValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EpisodeValidator>();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DoctorWhoCoreDbContext>(
    //DbContextOptions => DbContextOptions.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = DoctorWhoCore")
    ); // adding the content

//dependancy injection
builder.Services.AddScoped<IDoctorInfoRepository, DoctorInfoRepository>();
builder.Services.AddScoped<IDoctorManager, DoctorManager>();

builder.Services.AddScoped<IEpisodeInfoRepository, EpisodeInfoRepository>();
builder.Services.AddScoped<IEpisodeManager, EpisodeManager>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();   

app.UseAuthorization();

app.UseEndpoints(endpoints =>   endpoints.MapControllers());

app.MapControllers();

app.Run();
