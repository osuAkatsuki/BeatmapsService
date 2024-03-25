using BeatmapsService;
using BeatmapsService.Adapters;
using BeatmapsService.Caching;
using BeatmapsService.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));
builder.Configuration.AddEnvironmentVariables();

builder.Services
    .AddOptions<BeatmapOptions>()
    .Bind(builder.Configuration)
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICache, Cache>();

builder.Services.AddSingleton<IOsuAdapter, OsuAdapter>();
builder.Services.Decorate<IOsuAdapter, ResilientOsuAdapter>();

builder.Services.AddSingleton<IOsuService, OsuService>();
builder.Services.Decorate<IOsuService, CachingOsuService>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    var beatmapOptions = builder.Configuration.Get<BeatmapOptions>()!;
    options.Configuration = beatmapOptions.RedisConnectionString;
});

builder.Services.AddHttpClient();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddHttpContextAccessor();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.UseExceptionHandler();

app.Run();