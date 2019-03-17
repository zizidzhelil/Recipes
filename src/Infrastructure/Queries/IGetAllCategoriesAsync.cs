using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public interface IGetAllCategoriesAsync
    {
        Task<List<Category>> ExecuteAsync();
    }
}