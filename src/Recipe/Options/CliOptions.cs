using CommandLine;

namespace Recipe.Options
{
    public class CliOptions
    {
        [Option('f', "Functionality", Required = true, HelpText = @"Choose functionality between ""Recipes"" and ""Recipes by Category""")]
        public string Functionality { get; set; }

        [Option('n', "Name", HelpText = "Recipe name")]
        public string Name { get; set; }

        [Option('c', "Category", HelpText = "Category name")]
        public string Category { get; set; }
    }
}
