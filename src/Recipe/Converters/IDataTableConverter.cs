using Infrastructure.Models;
using System.Collections.Generic;
using System.Data;

namespace Recipe.Converters
{
    public interface IDataTableConverter
    {
        DataTable ConvertRecipeToDataTable(List<RecipeModel> recipeModel);
    }
}
