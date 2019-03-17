using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public interface IInsertIngredientsCommand
    {
        Task ExecuteAsync(List<string> ingredients);
    }
}
