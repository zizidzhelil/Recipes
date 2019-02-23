using CommandLine;

namespace Recipe.Options
{
    public class CliOptions
    {
        [Option('n', "Name", HelpText = "Recipe name")]
        public string Name { get; set; }
    }
}
