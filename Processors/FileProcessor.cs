using MultiScan.Processors.ProcessorInterfaces;

namespace MultiScan.Processors;

/// <summary>
/// Provides functionality to count occurrences of a specific character within a text file.
/// </summary>
public class FileProcessor : IFileProcessor
{
    /// <summary>
    /// The character to count within the file.
    /// </summary>
    public char Symbol {get; private set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="FileProcessor"/> class.
    /// </summary>
    /// <param name="symbol">The character to count.</param>
    public FileProcessor(char symbol)
    {
        Symbol = symbol;
    }

    /// <summary>
    /// Asynchronously counts the occurrences of the specified character in a file.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <returns>The number of times the specified character appears in the file.</returns>
    public async Task<int> CountSymbolsInFileAsync(string filePath)
    {
        string content = await File.ReadAllTextAsync(filePath);
        return content.Count(c => c == Symbol);
    }
}