using Core.Entities;
using DAL.Context;
using Infrastructure.Providers;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Queries
{
    public class GetAllCategoriesAsync : IGetAllCategoriesAsync
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public GetAllCategoriesAsync(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<List<Category>> ExecuteAsync()
        {
            using (RecipeContext context = new RecipeContext(_appSettingsProvider.ConnectionString))
            {
                return await context.Categories.ToListAsync();
            }
        }
    }
}