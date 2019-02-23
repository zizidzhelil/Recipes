using Core.Entities;
using DAL.Context;
using Infrastructure.Providers;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DAL.Queries
{
    public class GetRecipeByNameQueryAsync : IGetRecipeByNameQueryAsync
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public GetRecipeByNameQueryAsync(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<List<Recipe>> ExecuteAsync(string recipeName)
        {
            using (RecipeContext context = new RecipeContext(_appSettingsProvider.ConnectionString))
            {
                return await context.Recipes
                    .Where(x => x.Name.Contains(recipeName))
                    .Include(r => r.RecipeIngredients)
                    .ThenInclude(r => r.Ingredient)
                    .Include(x => x.RecipeIngredients)
                    .ThenInclude(x => x.Measurement)
                    .ToListAsync();
            }
        }
    }
}
