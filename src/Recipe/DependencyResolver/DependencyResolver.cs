using BL.DependencyResolver;
using Infrastructure.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.Providers;

namespace Recipe.DependencyResolver
{
   public static class DependendencyResolver
   {
      public static ServiceCollection RegisterConcreteTypes(this ServiceCollection serviceCollection, IConfigurationRoot configuration)
      {
         serviceCollection.AddSingleton<IAppSettingsProvider>(new AppSettingsProvider(configuration));

         serviceCollection.RegisterTypes();

         return serviceCollection;
      }
   }
}
