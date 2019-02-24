using Infrastructure.Queries;
using Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGetAllCategoryNamesQueryAsync _getAllCategoryNamesQueryAsync;

        public CategoryService(IGetAllCategoryNamesQueryAsync getAllCategoryNamesQueryAsync)
        {
            _getAllCategoryNamesQueryAsync = getAllCategoryNamesQueryAsync;
        }

        public async Task<List<string>> GetAllCategoryNamesAsync()
        {
            return await _getAllCategoryNamesQueryAsync.ExecuteAsync();
        }
    }
}
