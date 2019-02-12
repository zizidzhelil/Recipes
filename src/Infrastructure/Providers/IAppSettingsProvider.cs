namespace Infrastructure.Providers
{
   public interface IAppSettingsProvider
   {
      string ConnectionString { get; }
   }
}
