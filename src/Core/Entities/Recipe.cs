using System.Collections.Generic;

namespace Core.Entities
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public float PreparationTime { get; set; }

        public int NumberOfServings { get; set; }

        public int Calories { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
