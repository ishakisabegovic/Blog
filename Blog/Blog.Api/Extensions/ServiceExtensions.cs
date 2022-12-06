﻿using Blog.Infrastructure.Database;
using Blog.Repositories.RepositoryManager;
using Blog.Services.Logger;
using Blog.Services.ServiceManager;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureSqlContext(
                this IServiceCollection services,
                IConfiguration configuration) =>
                         services.AddDbContext<AppDbContext>(options => 
                         options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection")));

        public static void ConfigureCors(this IServiceCollection services) => 
            services
                .AddCors(options => { options
                .AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()); 
                });

        public static void ConfigureLoggerService(this IServiceCollection services) => 
            services
                .AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services
                .AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services
                .AddScoped<IServiceManager, ServiceManager>();
    }
}
