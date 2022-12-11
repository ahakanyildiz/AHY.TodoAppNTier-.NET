using AHY.ToDoAppNTier.Business.Mappings.AutoMapper;
using AHY.ToDoAppNTier.Business.Services.Abstract;
using AHY.ToDoAppNTier.Business.Services.Concrete;
using AHY.ToDoAppNTier.Business.ValidationRules;
using AHY.ToDoAppNTier.DataAccess.Contexts;
using AHY.ToDoAppNTier.DataAccess.UnitOfWork;
using AHY.ToDoAppNTier.Dtos.WorkDtos;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AHY.ToDoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\mssqllocaldb;database=ToDoDb;integrated security=true;");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IWorkService, WorkService>();

            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>,WorkUpdateDtoValidator>();
        }
    }
}
