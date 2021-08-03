using System;
using IntelitraderMobile.Services;
using IntelitraderMobile.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace IntelitraderMobile
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<APIUserService, APIUserService>();

            services.AddTransient<ItemsViewModel>();
            services.AddTransient<NewItemViewModel>();
            services.AddTransient<ItemDetailViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}