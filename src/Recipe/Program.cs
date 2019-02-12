using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.DependencyResolver;
using System;

namespace Recipe
{
   class Program
   {
      static void Main(string[] args)
      {
         IConfigurationRoot configuration = new ConfigurationBuilder()
               .AddJsonFile("appSettings.json", optional: true)
               .AddEnvironmentVariables()
               .Build();

         ServiceProvider serviceProvider = new ServiceCollection()
            .RegisterConcreteTypes(configuration)
            .BuildServiceProvider();

         var service = serviceProvider.GetService<ICategoryService>();
         Console.WriteLine(service.GetCategoriesAsync().GetAwaiter().GetResult());
      }
   }
}
