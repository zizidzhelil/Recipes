using Infrastructure.Models;
using System.Collections.Generic;
using System.Data;

namespace Cooking.Converters
{
    public interface IDataTableConverter
    {
        DataTable ConvertRecipeToDataTable(List<RecipeModel> recipeModel);
    }
}
