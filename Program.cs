using System.Diagnostics;
using MultiScan.Processors;

namespace MultiScan;

/// <summary>
/// The main entry point for the MultiScan application.
/// </summary>
class Program
{
    /// <summary>
    /// The main method that executes the MultiScan functionality.
    /// Parses command-line arguments, processes the directory, and outputs the results.
    /// </summary>
    /// <param name="args">Command-line arguments: directory path and symbol to count.</param>
    /// <exception cref="ArgumentException">Thrown if command-line arguments are invalid.</exception>
    /// <exception cref="DirectoryNotFoundException">Thrown if the specified directory does not exist.</exception>
    /// <exception cref="IOException">Thrown if an I/O error occurs during file processing.</exception>
    /// <exception cref="AggregateException">Thrown if any exception occurs during file processing.</exception>
    static async Task Main(string[] args)
    {
        try
        {
            // Create an instance of the command-line argument parser.
            var parser = new CommandLineArgumentsParser();

            // Parse the command-line arguments to get the directory path and the symbol to count.
            var path = parser.GetPathFromArgs(args);
            var symbol = parser.GetSymbolFromArgs(args);
            
            // Create instances of the file and directory processors.
            var fileProcessor = new FileProcessor(symbol);
            var directoryProcessor = new DirectoryProcessor(fileProcessor);

            // Start a stopwatch to measure the execution time.
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Asynchronously count the occurrences of the symbol in the specified directory.
            int totalSpaces = await directoryProcessor.CountSymbolsInDirectoryAsync(path);

            // Stop the stopwatch and display the results.
            stopwatch.Stop();

            Console.WriteLine($"Total spaces: {totalSpaces}");
            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
        }
        catch (Exception ex)
        {
            // Handle exceptions and display an error message.
            Console.WriteLine(string.Format("Error: {0}", ex.Message));
        }
        Console.ReadLine();
    }
}
