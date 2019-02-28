using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public interface IGetRecipesByIngredientsQueryAsync
    {
        Task<List<Recipe>> ExecuteAsync(List<string> ingredients);
    }
}
