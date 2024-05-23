using CrossCutting.DependencyInjection;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddSqlite(builder.Configuration.GetConnectionString("Sqlite")!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClinicProApi");
    });
    
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