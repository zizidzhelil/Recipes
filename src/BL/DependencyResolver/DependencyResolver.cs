using BL.Services;
using DAL.Queries;
using Infrastructure.Queries;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BL.DependencyResolver
{
    public static class DependencyResolver
    {
        public static ServiceCollection RegisterTypes(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IGetRecipeByNameQueryAsync, GetRecipeByNameQueryAsync>();
            serviceCollection.AddScoped<IGetRecipeByCategoryQueryAsync, GetRecipeByCategoryQueryAsync>();
            serviceCollection.AddScoped<IGetAllCategoryNamesQueryAsync, GetAllCategoryNamesQueryAsync>();
            serviceCollection.AddScoped<IGetRecipesByIngredientsQueryAsync, GetRecipesByIngredientsQueryAsync>();

            serviceCollection.AddScoped<IRecipeService, RecipeService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();

            return serviceCollection;
        }
    }
}
