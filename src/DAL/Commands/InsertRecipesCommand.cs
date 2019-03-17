using Core.Entities;
using DAL.Context;
using Infrastructure.Commands;
using Infrastructure.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Commands
{
    public class InsertRecipesCommand : IInsertRecipesCommand
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public InsertRecipesCommand(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task ExecuteAsync(List<Recipe> recipes)
        {
            using (RecipeContext context = new RecipeContext(_appSettingsProvider.ConnectionString))
            {
                await context.Recipes.AddRangeAsync(recipes);
                await context.SaveChangesAsync();
            }
        }
    }
}