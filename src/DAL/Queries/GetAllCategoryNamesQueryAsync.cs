using DAL.Context;
using Infrastructure.Providers;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Queries
{
    public class GetAllCategoryNamesQueryAsync : IGetAllCategoryNamesQueryAsync
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public GetAllCategoryNamesQueryAsync(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<List<string>> ExecuteAsync()
        {
            using (RecipeContext context = new RecipeContext(_appSettingsProvider.ConnectionString))
            {
                return await context.Categories.Select(x => x.Name).ToListAsync();
            }
        }
    }
}
