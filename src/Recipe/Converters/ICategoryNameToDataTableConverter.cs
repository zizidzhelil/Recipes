using System.Collections.Generic;
using System.Data;

namespace Recipe.Converters
{
    public interface ICategoryNameToDataTableConverter
    {
        DataTable ConvertCategoryToDataTable(List<string> categories);
    }
}
