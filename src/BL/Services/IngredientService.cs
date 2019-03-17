using Infrastructure.Commands;
using Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IInsertIngredientsCommand _insertIngredientsCommand;

        public IngredientService(IInsertIngredientsCommand insertIngredientsCommand)
        {
            _insertIngredientsCommand = insertIngredientsCommand;
        }

        public async Task InsertIngredients(List<string> ingredients)
        {
            await _insertIngredientsCommand.ExecuteAsync(ingredients);
        }
    }
}