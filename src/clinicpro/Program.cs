using CrossCutting.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Person.RestApi;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        ;
});

builder.Services.AddRootModule(builder.Configuration);

builder.Services.AddResponseCompression();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Main Project API", Version = "v1" });

        // Reference and scan the assemblies of class library projects
        var assemblies= AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            if (assembly.FullName.Contains("RestApi"))
                c.SwaggerDoc("myclasslibrary", new OpenApiInfo { Title = "MyClassLibrary API", Version = "v1" });
        }
    }
);

builder.Services.AddHealthChecks()
    .AddSqlite(builder.Configuration.GetConnectionString("Sqlite")!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    using var context = scope.ServiceProvider.GetRequiredService<DbContext>();
    context.Database.Migrate();
}

app.UseSerilogRequestLogging();

app.UseExceptionHandler(opt => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/_/health");

app.Run();