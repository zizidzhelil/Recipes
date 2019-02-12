using Infrastructure.Queries;
using Infrastructure.Services;
using System.Threading.Tasks;

namespace BL.Services
{
   public class CategoryService : ICategoryService
   {
      private readonly IGetCategoryQueryAsync _getCategoryQueryAsync;

      public CategoryService(IGetCategoryQueryAsync getCategoryQueryAsync)
      {
         _getCategoryQueryAsync = getCategoryQueryAsync;
      }

      public async Task<string> GetCategoriesAsync()
      {
         string categories = await _getCategoryQueryAsync.ExecuteAsync();
         return categories;
      }
   }
}
