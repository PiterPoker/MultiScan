using MultiScan.Processors.ProcessorInterfaces;

namespace MultiScan.Processors;

/// <summary>
/// Provides functionality to count occurrences of a specific character across all files within a directory.
/// </summary>
public class DirectoryProcessor : IDirectoryProcessor
{
    private readonly IFileProcessor _fileProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="DirectoryProcessor"/> class.
    /// </summary>
    /// <param name="fileProcessor">An instance of <see cref="IFileProcessor"/> used to count characters in individual files.</param>
    public DirectoryProcessor(IFileProcessor fileProcessor)
    {
        _fileProcessor = fileProcessor;
    }

    /// <summary>
    /// Asynchronously counts the occurrences of a specified character across all files in a directory.
    /// </summary>
    /// <param name="directoryPath">The path to the directory.</param>
    /// <returns>A task that returns the total count of the specified character across all files in the directory.</returns>
    /// <exception cref="DirectoryNotFoundException">Thrown if the specified directory does not exist.</exception>
    /// <exception cref="IOException">Thrown if an I/O error occurs while reading files in the directory.</exception>
    /// <exception cref="AggregateException">Thrown if any exception occurs during file processing.</exception>
    public async Task<int> CountSymbolsInDirectoryAsync(string directoryPath)
    {
        var files = Directory.GetFiles(directoryPath);
        var tasks = files.Select(file => _fileProcessor.CountSymbolsInFileAsync(file));
        var results = await Task.WhenAll(tasks);
        return results.Sum();
    }
}
