using ContactContractor.Application.Common.Mappings;
using ContactContractor.Application.Interfaces;
using ContactContractor.Persistence;
using System.Reflection;
using ContactContractor.Application;
using ContactContractor.WebApi.Middleware;

namespace ContactContractor.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); 

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
            });
            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(config =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();
            using (var serviceScoped = app.Services.CreateScope())
            {
                var services = serviceScoped.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occured while app initialization");
                }
            }
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.RoutePrefix = string.Empty;
                config.SwaggerEndpoint("swagger/v1/swagger.json", "ContactContractor Api");
            });
            app.UseCustomExceptionHandler();
            app.UseRouting(); 
            app.UseHttpsRedirection(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
