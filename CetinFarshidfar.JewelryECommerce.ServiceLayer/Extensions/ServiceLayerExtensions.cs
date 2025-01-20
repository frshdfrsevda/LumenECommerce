using CetinFarshidfar.JewelryECommerce.ServiceLayer.FluentValidations;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Helpers.Images;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagService, TagService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IImageHelper, ImageHelper>();

            services.AddAutoMapper(assembly);


            // FluentValidation servisini ekleyin
            services.AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();

            // FluentValidation'ı yapılandırın
            services.AddValidatorsFromAssemblyContaining<UserValidator>();

            // Global doğrulama seçeneklerini ayarlayın
            FluentValidation.ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");
            FluentValidation.ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, expression) => memberInfo.Name;

            return services;
        }
    }
}
