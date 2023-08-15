using CrudOperation.DataAccess;
using CrudOperation.DataAccess.UnitOfWork;
using CrudOperation.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CrudOperation.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();

            try
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Host.UseSerilog((context, configuration) =>
                    configuration.ReadFrom.Configuration(context.Configuration));

                // Add services to the container.
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

                builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseSerilogRequestLogging();

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }

            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }

            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
