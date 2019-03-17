using Core.Entities;

namespace Infrastructure.Models
{
    public class IngredientModel
    {
        public IngredientModel(string name, string measurement, float amount)
        {
            Name = name;
            Measurement = measurement;
            Amount = amount;
        }

        public IngredientModel() { }

        public string Name { get; set; }

        public string Measurement { get; set; }

        public float Amount { get; set; }

        public Ingredient ToIngredient()
        {
            var ingredient = new Ingredient
            {
                Name = Name         
            };

            return ingredient;
        }

        public override string ToString()
        {
            return $"{Amount} {Measurement} {Name}";
        }
    }
}