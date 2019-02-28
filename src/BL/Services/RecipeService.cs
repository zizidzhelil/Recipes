using Core.Entities;
using Infrastructure.Models;
using Infrastructure.Queries;
using Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IGetRecipeByNameQueryAsync _getRecipeByNameQueryAsync;
        private readonly IGetRecipeByCategoryQueryAsync _getRecipeByCategoryQueryAsync;
        private readonly IGetRecipesByIngredientsQueryAsync _getRecipesByIngredientsQueryAsync;

        public RecipeService(
            IGetRecipeByNameQueryAsync getRecipeByNameQueryAsync,
            IGetRecipeByCategoryQueryAsync getRecipeByCategoryQueryAsync,
            IGetRecipesByIngredientsQueryAsync getRecipesByIngredientsQueryAsync)
        {
            _getRecipeByNameQueryAsync = getRecipeByNameQueryAsync;
            _getRecipeByCategoryQueryAsync = getRecipeByCategoryQueryAsync;
            _getRecipesByIngredientsQueryAsync = getRecipesByIngredientsQueryAsync;
        }

        public async Task<List<RecipeModel>> GetRecipesAsync(string recipeName)
        {
            List<Recipe> recipes = await _getRecipeByNameQueryAsync.ExecuteAsync(recipeName);
            return recipes.Select(x => new RecipeModel(x)).ToList();
        }

        public async Task<List<RecipeModel>> GetRecipesByCategoryAsync(string categoryName)
        {
            List<Recipe> recipes = await _getRecipeByCategoryQueryAsync.ExecuteAsync(categoryName);
            return recipes.Select(x => new RecipeModel(x)).ToList();
        }

        public async Task<List<RecipeModel>> GetRecipesByIngredientsAsync(List<string> ingredients)
        {
            List<Recipe> recipes = await _getRecipesByIngredientsQueryAsync.ExecuteAsync(ingredients);
            return recipes.Select(x => new RecipeModel(x)).ToList();
        }
    }
}
