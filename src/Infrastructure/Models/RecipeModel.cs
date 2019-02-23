using Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Models
{
    public class RecipeModel
    {
        public RecipeModel(Recipe recipe)
        {
            Name = recipe.Name;
            Description = recipe.Description;
            Instructions = recipe.Instructions;
            PreparationTime = recipe.PreparationTime;
            NumberOfServings = recipe.NumberOfServings;
            Calories = recipe.Calories;
            Ingredients = recipe.RecipeIngredients
                .Select(r => new IngredientModel(
                    r.Ingredient.Name, 
                    r.Measurement.Name, 
                    r.Amount.ToString()))
                .ToList();

        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Instructions { get; set; }

        public float PreparationTime { get; set; }

        public int NumberOfServings { get; set; }

        public int Calories { get; set; }

        public List<IngredientModel> Ingredients { get; set; }
    }
}
