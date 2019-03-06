using Core.Entities;
using DAL.Context;
using Infrastructure.Commands;
using Infrastructure.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Commands
{
    public class InsertIngredientsCommand : IInsertIngredientsCommand
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public InsertIngredientsCommand(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task Execute(List<string> ingredients)
        {
            using (RecipeContext context = new RecipeContext(_appSettingsProvider.ConnectionString))
            {
                foreach (var ingredient in ingredients)
                {
                    context.Ingredients.Add(new Ingredient { Name = ingredient });
                }

                context.SaveChanges();
            }
        }
    }
}
