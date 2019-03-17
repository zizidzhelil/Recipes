using Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Models
{
    public class RecipeModel
    {
        public RecipeModel()
        {

        }

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
                    r.Amount))
                .ToList();

        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Instructions { get; set; }

        public float PreparationTime { get; set; }

        public int NumberOfServings { get; set; }

        public int Calories { get; set; }

        public List<IngredientModel> Ingredients { get; set; }

        public Recipe ToRecipe(
            Dictionary<string, int> categories,
            Dictionary<string, int> ingredients,
            Dictionary<string, int> measurements)
        {
            var recipe = new Recipe
            {
                Name = Name,
                Description = Description,
                Instructions = Instructions,
                PreparationTime = PreparationTime,
                NumberOfServings = NumberOfServings,
                CategoryId = categories[Category.ToLower()],
                Calories = Calories,
                RecipeIngredients = Ingredients.Select(i => new RecipeIngredient()
                {
                    Amount = i.Amount,
                    IngredientId = ingredients[i.Name.ToLower()],
                    MeasurementId = measurements[i.Measurement.ToLower()]
                }).ToList()
            };

            return recipe;
        }
    }
}