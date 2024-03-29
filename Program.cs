
using DevJobs.API.Persistence;
using DevJobs.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var connectionString = builder.Configuration.GetConnectionString("DevJobsCs");
//builder.Services.AddDbContext<DevJobsContext>
//    (options => options.UseMySql(connectionString,
 //    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql")));

builder.Services
    .AddDbContext<DevJobsContext>(options => 
        options.UseInMemoryDatabase("DevJobs"));

builder.Services.AddScoped<IJobVacancyRepository, JobVacancyRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevJobs.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "SandokanAlves",
            Email = "sandokan.alves@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/sandokanalves/")
        }
    });

    var xmlFile = $"DevJobs.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    });   


var app = builder.Build();

// Configure the HTTP request pipeline.

 app.UseSwagger();
 app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
