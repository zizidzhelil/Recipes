namespace Infrastructure.Models
{
    public class IngredientModel
    {
        public IngredientModel(string name, string measurement, string amount)
        {
            Name = name;
            Measurement = measurement;
            Amount = amount;
        }

        public string Name { get; set; }

        public string Measurement { get; set; }

        public string Amount { get; set; }

        public override string ToString()
        {
            return $"{Amount} {Measurement} {Name}";
        }
    }
}
