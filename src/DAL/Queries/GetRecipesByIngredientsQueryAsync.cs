using Core.Entities;
using DAL.Context;
using Infrastructure.Providers;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Queries
{
    public class GetRecipesByIngredientsQueryAsync : IGetRecipesByIngredientsQueryAsync
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public GetRecipesByIngredientsQueryAsync(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<List<Recipe>> ExecuteAsync(List<string> ingredients)
        {
            using (RecipeContext context = new RecipeContext(_appSettingsProvider.ConnectionString))
            {
                List<Recipe> recipes = new List<Recipe>();
                List<Recipe> allRecipes = await context.Recipes
                    .Include(x => x.RecipeIngredients)
                    .ThenInclude(x => x.Ingredient)
                    .Include(x => x.RecipeIngredients)
                    .ThenInclude(x => x.Measurement)
                    .ToListAsync();

                foreach (var recipe in allRecipes)
                {
                    if (ingredients.All(i => recipe.RecipeIngredients.Select(x => x.Ingredient.Name).Contains(i)))
                    {
                        recipes.Add(recipe);
                    }
                }

                return recipes;
            }
        }
    }
}
