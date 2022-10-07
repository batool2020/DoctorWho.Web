using DoctorWho.Db;
using DoctorWho.Web.Services;
using DoctorWho.Web.Validators;
using episodeWho.Web.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())).AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddValidatorsFromAssemblyContaining<DoctorValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EpisodeValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AuthorValidator>();


builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DoctorWhoCoreDbContext>(
   options => {
       options.UseSqlServer(
       builder.Configuration["ConnectionStrings:CityInfoDBConnectionString"]); 
       }); // adding the content

//dependancy injection
builder.Services.AddScoped<IDoctorInfoRepository, DoctorInfoRepository>();
builder.Services.AddScoped<IDoctorManager, DoctorManager>();

builder.Services.AddScoped<IEpisodeInfoRepository, EpisodeInfoRepository>();
builder.Services.AddScoped<IEpisodeManager, EpisodeManager>();


builder.Services.AddScoped<IAuthorRepository, AuthorInfoRepository>();
builder.Services.AddScoped<IAuthorManager, AuthorManager>();

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
