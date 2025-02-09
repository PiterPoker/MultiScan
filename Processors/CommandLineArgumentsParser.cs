using MultiScan.Processors.ProcessorInterfaces;

namespace MultiScan.Processors;

/// <summary>
/// Parses command-line arguments to extract the directory path and the character to count.
/// </summary>
public class CommandLineArgumentsParser : IArgumentsParser
{
    /// <summary>
    /// Extracts the directory path from the command-line arguments.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    /// <returns>The directory path.</returns>
    /// <exception cref="ArgumentException">Thrown if no path is provided or the path is invalid.</exception>
    public string GetPathFromArgs(string[] args)
    {
        if (args.Length >= 1)
        if (!Directory.Exists(args[0]))
            throw new ArgumentException(string.Format("Directory (path: {0}) not found", args[0]));
        return args[0];
    }

    /// <summary>
    /// Extracts the character to count from the command-line arguments.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    /// <returns>The character to count.</returns>
    /// <exception cref="ArgumentException">Thrown if no symbol is provided or the symbol is invalid.</exception>
    public char GetSymbolFromArgs(string[] args)
    {
        if (args.Length < 2)
            throw new ArgumentException(string.Format("Symbol not found"));
        if (!char.TryParse(args[1], out var symbol))
            throw new ArgumentException(string.Format("Cannot parse string (value: {0}) to char.", args[1]));
        return symbol;
    }
}