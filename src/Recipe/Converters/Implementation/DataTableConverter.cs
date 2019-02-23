using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Recipe.Converters.Implementation
{
    public class DataTableConverter : IDataTableConverter
    {
        public DataTable ConvertRecipeToDataTable(List<RecipeModel> recipeModel)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Parameters");
            dataTable.Columns.Add("Information");

            foreach (var recipe in recipeModel)
            {
                dataTable.Rows.Add("Name", recipe.Name);
                dataTable.Rows.Add("Description", recipe.Description);
                dataTable.Rows.Add("Preparation Time", recipe.PreparationTime);
                dataTable.Rows.Add("Number Of Servings", recipe.NumberOfServings);
                dataTable.Rows.Add("Calories", recipe.Calories);
                dataTable.Rows.Add("Ingredients", $"{Environment.NewLine}   {string.Join($"{Environment.NewLine}   ", recipe.Ingredients)}");
                dataTable.Rows.Add($"{Environment.NewLine}Instruction", recipe.Instructions.Replace($"{Environment.NewLine}", "").Replace(".", $".{Environment.NewLine}"));
            }

            return dataTable;
        }
    }
}