using DoctorWho.Db;
using DoctorWho.Web.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DoctorWhoCoreDbContext>(
    //DbContextOptions => DbContextOptions.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = DoctorWhoCore")
    ); // adding the content

//dependancy injection
builder.Services.AddScoped<IDoctorInfoRepository, DoctorInfoRepository>();

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
