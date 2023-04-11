using Courses.API.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

builder.Logging.AddSerilog(new LoggerConfiguration()
    .WriteTo.Debug()
    .WriteTo.Console()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger());

_ = builder.Services.ConfigureDependedServices();

var app = builder.Build();

app.ConfigureHttpRequestPipeline();

app.Run();
