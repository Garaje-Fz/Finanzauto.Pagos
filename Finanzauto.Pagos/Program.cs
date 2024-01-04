using dotenv.net;
using Finanzauto.Pagos.Application;
using Finanzauto.Pagos.Infrastructure;
using Finanzauto.Pagos.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//Load environment variables
DotEnv.Load();
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AutomaticAuthentication = false;
});
//Load appsettings.json
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{envName}.json", optional: true, reloadOnChange: true);
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add layer services
builder.Services
    .AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();
app.AddMiddlewares();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
