using System;
using Burak.Application.Inveon.Business.Mapper;
using Burak.Application.Inveon.Business.Services;
using Burak.Application.Inveon.Business.Validator;
using Burak.Application.Inveon.Data;
using Burak.Application.Inveon.Utilities.ConfigModels;
using Burak.Application.Inveon.Utilities.Filters;
using Burak.Application.Inveon.Utilities.Helper;
using Burak.Application.Inveon.Utilities.ValidationHelper.ValidationResolver;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using AutoMapper;
using Burak.Application.Inveon.Controllers;

namespace Burak.Application.Inveon
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddLogging(builder => builder.AddNLog());
            services.AddMvc(options => options.Filters.Add<GeneralExceptionFilter>());
            services.AddMvc(options => options.EnableEndpointRouting = false);
            AddSelectedDataStorage(services);
            AddMappers(services);
            AddValidations(services);
            AddBusinessServices(services);

            services.AddSwaggerGen(c =>
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "E-Commerce API", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(option => option.AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin());

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "E-Commerce API");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseStaticFiles();
        }

        private void AddSelectedDataStorage(IServiceCollection services)
        {
            DataStorage dataStorage = ConfigurationHelper.GetDataStorage(Configuration);

            switch (dataStorage.DataStorageType)
            {
                case DataStorageTypes.SqlServer:
                    services.AddDbContext<DataContext>(builder => builder.UseSqlServer(dataStorage.ConnectionString));
                    break;
                case DataStorageTypes.MySQL:
                    services.AddDbContext<DataContext>(builder => builder.UseMySql(dataStorage.ConnectionString));
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{dataStorage.DataStorageType} has not been pre-defined");
            }
        }

        private void AddMappers(IServiceCollection services)
        {
            //TODO: Create and add which model mapped to which
            services.AddAutoMapper(typeof(UserMapper));
            services.AddAutoMapper(typeof(ProductMapper));
        }

        private void AddValidations(IServiceCollection services)
        {
            //TODO: Add Request Validators
            services.AddSingleton<IValidatorResolver, ValidatorResolver>();
            services.AddSingleton<IValidator, UserValidator>();
            services.AddSingleton<IValidator, UpdateProductRequestValidator>();
            services.AddSingleton<IValidator, LoginRequestValidator>();
        }

        private void AddBusinessServices(IServiceCollection services)
        {
            //TODO: Add Services (external,internal)
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserApiController, UserApiController>();
            services.AddScoped<IProductApiController, ProductApiController>();
        }
    }
}
