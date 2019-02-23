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

        public RecipeService(IGetRecipeByNameQueryAsync getRecipeByNameQueryAsync)
        {
            _getRecipeByNameQueryAsync = getRecipeByNameQueryAsync;
        }

        public async Task<List<RecipeModel>> GetRecipesAsync(string recipeName)
        {
            List<Recipe> recipes = await _getRecipeByNameQueryAsync.ExecuteAsync(recipeName);

            return recipes.Select(x => new RecipeModel(x)).ToList();
        }
    }
}
