using System.Threading.Tasks;

namespace Infrastructure.Services
{
   public interface ICategoryService
   {
      Task<string> GetCategoriesAsync();
   }
}
