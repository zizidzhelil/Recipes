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
    public class GetRecipeByCategoryQueryAsync : IGetRecipeByCategoryQueryAsync
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public GetRecipeByCategoryQueryAsync(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<List<Recipe>> ExecuteAsync(string categoryName)
        {
            using (RecipeContext context = new RecipeContext(_appSettingsProvider.ConnectionString))
            {
                return await context.Recipes
                    .Include(x => x.Category)
                    .Where(x => x.Category.Name.Contains(categoryName))
                    .Include(r => r.RecipeIngredients)
                    .ThenInclude(r => r.Ingredient)
                    .Include(x => x.RecipeIngredients)
                    .ThenInclude(x => x.Measurement)
                    .ToListAsync();
            }
        }
    }
}
