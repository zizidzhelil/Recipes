using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IIngredientService
    {
        Task InsertIngredients(List<string> ingredients);
    }
}