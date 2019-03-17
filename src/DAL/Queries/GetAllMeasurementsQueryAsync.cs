using Core.Entities;
using DAL.Context;
using Infrastructure.Providers;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Queries
{
    public class GetAllMeasurementsQueryAsync : IGetAllMeasurementsQueryAsync
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public GetAllMeasurementsQueryAsync(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<List<Measurement>> ExecuteAsync()
        {
            using (RecipeContext context = new RecipeContext(_appSettingsProvider.ConnectionString))
            {
                return await context.Measurements.ToListAsync();
            }
        }
    }
}