using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public interface IGetRecipeByCategoryQueryAsync
    {
        Task<List<Recipe>> ExecuteAsync(string categoryName);
    }
}
