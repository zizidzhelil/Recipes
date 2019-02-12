using System.Threading.Tasks;

namespace Infrastructure.Queries
{
   public interface IGetCategoryQueryAsync
   {
      Task<string> ExecuteAsync();
   }
}
