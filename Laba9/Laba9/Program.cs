using Laba9.Models;
using Laba9.Services;
using Microsoft.OpenApi.Models;
using NoteApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IHistoryService, HistoryService>();
builder.Services.AddScoped<IReminderService, ReminderService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IVersionService, VersionService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "v1", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "v2", Version = "v2" });
    c.SwaggerDoc("v3", new OpenApiInfo { Title = "v3", Version = "v3" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
        c.SwaggerEndpoint("/swagger/v3/swagger.json", "v3");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
