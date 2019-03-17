using Core.Entities;
using Infrastructure.Commands;
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
        private readonly IGetAllCategoriesAsync _getAllCategoriesAsync;
        private readonly IGetAllIngredientsQueryAsync _getAllIngredientsQueryAsync;
        private readonly IGetAllMeasurementsQueryAsync _getAllMeasurementsQueryAsync;
        private readonly IInsertRecipesCommand _insertRecipesCommand;

        public RecipeService(
            IGetRecipeByNameQueryAsync getRecipeByNameQueryAsync,
            IGetRecipeByCategoryQueryAsync getRecipeByCategoryQueryAsync,
            IGetRecipesByIngredientsQueryAsync getRecipesByIngredientsQueryAsync,
            IGetAllCategoriesAsync getAllCategoriesAsync,
            IGetAllIngredientsQueryAsync getAllIngredientsQueryAsync,
            IGetAllMeasurementsQueryAsync getAllMeasurementsQueryAsync,
            IInsertRecipesCommand insertRecipesCommand)
        {
            _getRecipeByNameQueryAsync = getRecipeByNameQueryAsync;
            _getRecipeByCategoryQueryAsync = getRecipeByCategoryQueryAsync;
            _getRecipesByIngredientsQueryAsync = getRecipesByIngredientsQueryAsync;
            _getAllCategoriesAsync = getAllCategoriesAsync;
            _getAllIngredientsQueryAsync = getAllIngredientsQueryAsync;
            _getAllMeasurementsQueryAsync = getAllMeasurementsQueryAsync;
            _insertRecipesCommand = insertRecipesCommand;
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

        public async Task InsertRecipesAsync(List<RecipeModel> recipesModel)
        {
            Dictionary<string, int> recipeCategories = (await _getAllCategoriesAsync.ExecuteAsync()).ToDictionary(c => c.Name.ToLower(), c => c.Id);
            Dictionary<string, int> recipeIngredients = (await _getAllIngredientsQueryAsync.ExecuteAsync()).ToDictionary(i => i.Name.ToLower(), i => i.Id);
            Dictionary<string, int> recipeMeasurements = (await _getAllMeasurementsQueryAsync.ExecuteAsync()).ToDictionary(m => m.Name.ToLower(), m => m.Id);

            List<Recipe> recipes = recipesModel.Select(r => r.ToRecipe(recipeCategories, recipeIngredients, recipeMeasurements)).ToList();
            await _insertRecipesCommand.ExecuteAsync(recipes);
        }
    }
}