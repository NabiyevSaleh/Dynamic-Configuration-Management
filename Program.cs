
namespace DynamicConfigurationManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration
            .AddJsonFile("customsettings.json", optional: false, reloadOnChange: true);

            // Add services to the container.

            builder.Services.AddControllers();
            
            bool enableSwagger = builder.Configuration.GetValue<bool>("EnableSwagger");
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (enableSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
