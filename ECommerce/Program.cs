using ECommerce.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomServices(builder.Configuration);

var app = builder.Build();

app.UseCustomMiddlewares(app.Environment);

app.Run();
