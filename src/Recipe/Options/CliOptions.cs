using CommandLine;

namespace Recipe.Options
{
    public class CliOptions
    {
        [Option('f', "Functionality", Required = true, HelpText = @"Choose functionality between ""Recipes"", ""Recipes by Category"", ""Categories"", ""Recipes by ingredients"", ""Insert Ingredients""")]
        public string Functionality { get; set; }

        [Option('n', "Name", HelpText = "Recipe name")]
        public string Name { get; set; }

        [Option('c', "Category", HelpText = "Category name")]
        public string Category { get; set; }

        [Option('i', "Ingredients", HelpText = "Ingredients")]
        public string Ingredients { get; set; }
    }
}
