using Core.Entities;
using DAL.Context;
using Infrastructure.Providers;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Queries
{
    public class GetAllIngredientsQueryAsync : IGetAllIngredientsQueryAsync
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public GetAllIngredientsQueryAsync(IAppSettingsProvider appSettingsProvider)
        {
            this._appSettingsProvider = appSettingsProvider;
        }

        public async Task<List<Ingredient>> ExecuteAsync()
        {
            using (RecipeContext context = new RecipeContext(_appSettingsProvider.ConnectionString))
            {
                return await context.Ingredients.ToListAsync();
            }
        }
    }
}