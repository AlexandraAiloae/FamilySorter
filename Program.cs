using FamilySorter.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure services
ConfigureServices(builder.Services);

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

// Configure services
void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IFamilyService, FamilyService>();
    services.AddScoped<IDataParsingService, DataParsingService>();
    services.AddScoped<IFileParsingService, FileParsingService>();
    services.AddScoped<IFileWritingService, FileWritingService>();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}
