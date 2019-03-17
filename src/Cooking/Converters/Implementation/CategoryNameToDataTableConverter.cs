using System.Collections.Generic;
using System.Data;

namespace Cooking.Converters.Implementation
{
    public class CategoryNameToDataTableConverter : ICategoryNameToDataTableConverter
    {
        public DataTable ConvertCategoryToDataTable(List<string> categories)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Parameters");
            dataTable.Columns.Add("Information");

            foreach (var category in categories)
            {
                dataTable.Rows.Add("Name", category);
            }

            return dataTable;
        }
    }
}
