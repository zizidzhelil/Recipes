using System.Collections.Generic;
using System.Data;

namespace Cooking.Converters
{
    public interface ICategoryNameToDataTableConverter
    {
        DataTable ConvertCategoryToDataTable(List<string> categories);
    }
}
