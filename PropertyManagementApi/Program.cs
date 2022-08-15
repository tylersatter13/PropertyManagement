using System;
using System.Linq;
using Azure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PropertyManagement;
using PropertyManagementRepository.Interfaces;
using PropertyManagementServices.Interfaces;
using PropertyManagementServices.Services;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("AppConfig");

builder.Host.ConfigureAppConfiguration(builder =>
    {
        var appUri = builder.Build().GetConnectionString("appConfiguration");

        //Connect to your App Config Store using the connection string
        builder.AddAzureAppConfiguration(options =>
        {
            var credential = new DefaultAzureCredential();
            options.Connect(new Uri(appUri), credential)
                   .Select("ConnectionString");
        
        });
    })
    .ConfigureServices(services =>
    {
        services.AddControllersWithViews();
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First())
    );

builder.Services.AddScoped<IMaintenanceRequestService, MaintenanceRequestService>();
builder.Services.AddScoped<IMaintenanceRequestRepository, MaintenanceRequestRepository>();
builder.Services.AddScoped<EFDBContext>();

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