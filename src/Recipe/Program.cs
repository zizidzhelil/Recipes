using CommandLine;
using ConsoleTableExt;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.Converters;
using Recipe.DependencyResolver;
using Recipe.Options;
using Recipe.Writers;

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
                
            Parser.Default.ParseArguments<CliOptions>(args)
                .WithParsed<CliOptions>(o =>
                {
                    var recipeService = serviceProvider.GetService<IRecipeService>();
                    var result = recipeService.GetRecipesAsync(o.Name).GetAwaiter().GetResult(); 

                    var recipeConverter = serviceProvider.GetService<IDataTableConverter>();
                    var recipeDataTable = recipeConverter.ConvertRecipeToDataTable(result);                   

                    ConsoleTableBuilder
                           .From(recipeDataTable)
                           .WithFormat(ConsoleTableBuilderFormat.MarkDown)
                           .WithOptions(new ConsoleTableBuilderOption())
                           .Export();

                    IWriter writer = serviceProvider.GetService<IWriter>();
                    writer.Write(recipeDataTable);
                });
        }
    }
}