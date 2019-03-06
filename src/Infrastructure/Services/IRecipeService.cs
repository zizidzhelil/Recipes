using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeModel>> GetRecipesAsync(string recipeName);

        Task<List<RecipeModel>> GetRecipesByCategoryAsync(string categoryName);

        Task<List<RecipeModel>> GetRecipesByIngredientsAsync(List<string> ingredients);
    }
}