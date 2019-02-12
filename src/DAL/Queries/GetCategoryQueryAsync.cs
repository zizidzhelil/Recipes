using DAL.Context;
using Infrastructure.Providers;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Queries
{
   public class GetCategoryQueryAsync : IGetCategoryQueryAsync
   {
      private readonly IAppSettingsProvider appSettingsProvider;

      public GetCategoryQueryAsync(IAppSettingsProvider appSettingsProvider)
      {
         this.appSettingsProvider = appSettingsProvider;
      }

      public async Task<string> ExecuteAsync()
      {
         using (RecipeContext context = new RecipeContext(appSettingsProvider.ConnectionString))
         {
            StringBuilder sb = new StringBuilder();
            var categories = await context.Categories.ToListAsync();

            categories.ForEach(c => sb.AppendLine(c.Name));

            return sb.ToString();
         }
      }
   }
}
