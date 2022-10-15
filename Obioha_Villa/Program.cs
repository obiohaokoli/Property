using Microsoft.EntityFrameworkCore;
using Obioha_VillaAPI.Configuration;
using Obioha_VillaAPI.Data;
using Obioha_VillaAPI.Logger;
using Obioha_VillaAPI.Repository;
using Obioha_VillaAPI.Repository.IRepository;
using Serilog;
using ILogging = Obioha_VillaAPI.Logger.ILogging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding serilog to the program
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//  .WriteTo.File("log/villarLog.txt", rollingInterval: RollingInterval.Day).CreateLogger();
//builder.Host.UseSerilog();

// configure the connectionstring
builder.Services.AddDbContext<ApplicationDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

//Adding Mapping Configuration fil
builder.Services.AddAutoMapper(typeof(MappingConfiguration));


//option.ReturnHttpNotAcceptable = true (only json is allowed)
    builder.Services.AddControllers(
       // option => {option.ReturnHttpNotAcceptable = true } //allows only json
    )
    .AddNewtonsoftJson()//for using json
    .AddXmlDataContractSerializerFormatters();//for allowing xml


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILogging, Logging>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
