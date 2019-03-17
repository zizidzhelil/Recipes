using Common.Constants;
using Infrastructure.Providers;
using Microsoft.Extensions.Configuration;

namespace Cooking.Providers
{
   public class AppSettingsProvider : IAppSettingsProvider
   {
      private readonly IConfigurationRoot _configuration;

      public AppSettingsProvider(IConfigurationRoot configuration)
      {
         _configuration = configuration;
      }

      public string ConnectionString => _configuration[AppSettingsConstants.ConnectionString];
   }
}
