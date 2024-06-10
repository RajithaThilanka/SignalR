
using Microsoft.AspNetCore.SignalR;
using TaskManaget.API.TaskHubServices;

namespace TaskManaget.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();
            
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("allowedOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            } 
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors("allowedOrigin");
            app.MapControllers();
            app.MapHub<TaskHub>("/task-hub");

            app.Run();
        }
    }
}
