namespace Contacts.CLI.Input;

public class ArgumentExtractor : IArgumentExtractor
{
    private const int ArgumentsIndex = 2;
    
    public List<string> Extract()
    {
        var args = Environment.GetCommandLineArgs().ToList();
        if (args.Count <= ArgumentsIndex)
        {
            return new();
        }
        
        return args.GetRange(ArgumentsIndex, args.Count - ArgumentsIndex);
    }
}