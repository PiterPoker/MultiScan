namespace MultiScan.Processors.ProcessorInterfaces;

/// <summary>
/// Defines the interface for parsing command-line arguments.
/// </summary>
public interface IArgumentsParser
{
    /// <summary>
    /// Extracts the directory path from the command-line arguments.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    /// <returns>The directory path.</returns>
    public string GetPathFromArgs(string[] args);
    
    /// <summary>
    /// Extracts the character to count from the command-line arguments.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    /// <returns>The character to count.</returns>
    public char GetSymbolFromArgs(string[] args);
}