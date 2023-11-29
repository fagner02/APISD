using Microsoft.OpenApi.Models;
using Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "SD" }));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SD"));

List<BaseRoute> routes = BaseRoute.GetRoutes(app);

app.Run();

