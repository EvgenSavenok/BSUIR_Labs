using Application.Services;
using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddAutoMapper(typeof(AuthorService).Assembly);

var app = builder.Build();

app.MapControllers();
app.ConfigureExceptionHandler();

app.Run();