using BL.DependencyResolver;
using Infrastructure.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cooking.Converters;
using Cooking.Converters.Implementation;
using Cooking.Providers;
using Cooking.Readers;
using Cooking.Readers.Implementation;
using Cooking.Writers;
using Cooking.Writers.Implementation;

namespace Cooking.DependencyResolver
{
    public static class DependendencyResolver
    {
        public static ServiceCollection RegisterConcreteTypes(this ServiceCollection serviceCollection, IConfigurationRoot configuration)
        {      
            serviceCollection.AddSingleton<IAppSettingsProvider>(new AppSettingsProvider(configuration));

            serviceCollection.AddScoped<IDataTableConverter, DataTableConverter>();
            serviceCollection.AddScoped<ICategoryNameToDataTableConverter, CategoryNameToDataTableConverter>();
           
            serviceCollection.AddScoped<IWriter, Writer>();

            serviceCollection.AddScoped<IDataReader, DataReader>();

            serviceCollection.RegisterTypes();

            return serviceCollection;
        }
    }
}