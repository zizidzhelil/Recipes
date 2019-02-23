using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public interface IGetRecipeByNameQueryAsync
    {
        Task<List<Recipe>> ExecuteAsync(string recipeName);
    }
}
