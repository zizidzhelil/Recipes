using CommandLine;
using ConsoleTableExt;
using Cooking.Converters;
using Cooking.DependencyResolver;
using Cooking.Options;
using Cooking.Readers;
using Cooking.Writers;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
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
                    if (o.Functionality == "Recipes by Category")
                    {
                        var recipeByCategoryService = serviceProvider.GetService<IRecipeService>();
                        var result = recipeByCategoryService.GetRecipesByCategoryAsync(o.Category).GetAwaiter().GetResult();

                        var recipeConverter = serviceProvider.GetService<IDataTableConverter>();
                        var recipeDataTable = recipeConverter.ConvertRecipeToDataTable(result);

                        ConsoleTableBuilder
                               .From(recipeDataTable)
                               .WithFormat(ConsoleTableBuilderFormat.MarkDown)
                               .WithOptions(new ConsoleTableBuilderOption())
                               .Export();

                        IWriter writer = serviceProvider.GetService<IWriter>();
                        writer.Write(recipeDataTable);
                    }
                    else if (o.Functionality == "Recipes")
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
                    }
                    else if (o.Functionality == "Categories")
                    {
                        var categoryService = serviceProvider.GetService<ICategoryService>();
                        var result = categoryService.GetAllCategoryNamesAsync().GetAwaiter().GetResult();

                        var categoryConverter = serviceProvider.GetService<ICategoryNameToDataTableConverter>();
                        var categoryDataTable = categoryConverter.ConvertCategoryToDataTable(result);

                        ConsoleTableBuilder
                               .From(categoryDataTable)
                               .WithFormat(ConsoleTableBuilderFormat.MarkDown)
                               .WithOptions(new ConsoleTableBuilderOption())
                               .Export();

                        IWriter writer = serviceProvider.GetService<IWriter>();
                        writer.Write(categoryDataTable);
                    }
                    else if (o.Functionality == "Recipes by ingredients")
                    {
                        var recipeService = serviceProvider.GetService<IRecipeService>();
                        var result = recipeService.GetRecipesByIngredientsAsync(o.Ingredients.Split(", ", StringSplitOptions.None).ToList()).GetAwaiter().GetResult();

                        var recipeConverter = serviceProvider.GetService<IDataTableConverter>();
                        var recipeDataTable = recipeConverter.ConvertRecipeToDataTable(result);

                        ConsoleTableBuilder
                               .From(recipeDataTable)
                               .WithFormat(ConsoleTableBuilderFormat.MarkDown)
                               .WithOptions(new ConsoleTableBuilderOption())
                               .Export();

                        IWriter writer = serviceProvider.GetService<IWriter>();
                        writer.Write(recipeDataTable);
                    }
                    else if (o.Functionality == "Insert Ingredients")
                    {
                        var ingredientService = serviceProvider.GetService<IIngredientService>();
                        ingredientService.InsertIngredients(o.Ingredients.Split(", ", StringSplitOptions.None).ToList()).GetAwaiter().GetResult();
                    }
                    else if (o.Functionality == "Insert Recipes")
                    {
                        var recipeService = serviceProvider.GetService<IRecipeService>();

                        IDataReader reader = serviceProvider.GetService<IDataReader>();
                        List<RecipeModel> recipes = reader.Read(o.Path);

                        recipeService.InsertRecipesAsync(recipes).GetAwaiter().GetResult();
                    }
                });
        }
    }
}