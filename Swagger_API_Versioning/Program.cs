using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swagger_API_Versioning.Filters;
using Swagger_API_Versioning.Interfaces;
using Swagger_API_Versioning.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

#region APi Versioning Region
builder.Services.AddMvc();
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);       
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Employees",
        Description = "Employees V1"
    });

    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "Departments",
        Description = "Departments V2"
    });

    c.ResolveConflictingActions(a => a.First());

    c.OperationFilter<RemoveVersionFromParamter>();
    c.DocumentFilter<ReplaceVersionWithExactValueInPath>();
});
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/v1/swagger.json", "API V1");
        c.SwaggerEndpoint($"/swagger/v2/swagger.json", "API V2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
