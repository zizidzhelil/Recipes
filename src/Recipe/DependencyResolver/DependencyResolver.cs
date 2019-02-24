using BL.DependencyResolver;
using Infrastructure.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.Converters;
using Recipe.Converters.Implementation;
using Recipe.Providers;
using Recipe.Writers;
using Recipe.Writers.Implementation;

namespace Recipe.DependencyResolver
{
    public static class DependendencyResolver
    {
        public static ServiceCollection RegisterConcreteTypes(this ServiceCollection serviceCollection, IConfigurationRoot configuration)
        {      
            serviceCollection.AddSingleton<IAppSettingsProvider>(new AppSettingsProvider(configuration));

            serviceCollection.AddScoped<IDataTableConverter, DataTableConverter>();
            serviceCollection.AddScoped<ICategoryNameToDataTableConverter, CategoryNameToDataTableConverter>();
           
            serviceCollection.AddScoped<IWriter, Writer>();

            serviceCollection.RegisterTypes();

            return serviceCollection;
        }
    }
}