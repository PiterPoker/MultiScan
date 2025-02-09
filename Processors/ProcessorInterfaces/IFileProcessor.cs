namespace MultiScan.Processors.ProcessorInterfaces;

/// <summary>
/// Defines the interface for a file processor that counts character occurrences.
/// </summary>
public interface IFileProcessor
{
    /// <summary>
    /// Asynchronously counts the occurrences of a specified character in a file.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <returns>A task that returns the number of times the specified character appears in the file.</returns>
    public Task<int> CountSymbolsInFileAsync(string filePath);
}