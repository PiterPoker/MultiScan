namespace MultiScan.Processors.ProcessorInterfaces;

/// <summary>
/// Defines the interface for a directory processor that counts character occurrences across multiple files.
/// </summary>
public interface IDirectoryProcessor
{
    /// <summary>
    /// Asynchronously counts the occurrences of a specified character across all files in a directory.
    /// </summary>
    /// <param name="directoryPath">The path to the directory.</param>
    /// <returns>A task that returns the total count of the specified character across all files in the directory.</returns>
    public Task<int> CountSymbolsInDirectoryAsync(string directoryPath);
}