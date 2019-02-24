using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public interface IGetAllCategoryNamesQueryAsync
    {
        Task<List<string>> ExecuteAsync();
    }
}
