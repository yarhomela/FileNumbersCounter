using FileNumbersCounter.Services;
using static FileNumbersCounter.Constants.Constants;

internal class Program
{

    private static async Task Main(string[] args)
    {
        try
        {
            var directoryService = new DirectoryService();
            var fileService = new TextFileService();
            var linesCalculator = new LinesCalculatorService();

            Console.WriteLine(PROJECT_DESCRIPTION);
            Console.WriteLine(PRESS_ANY_KEY_TO_START);
            Console.ReadKey();
            Console.WriteLine(PLEASE_ENTER_FILE_PATH);

            var enteredText = Console.ReadLine();
            var filePath = directoryService.TryToGetValidPath(enteredText!);
            var allFileText = await fileService.GetFileTextData(filePath);

            var maxSumLineNumber = linesCalculator.GetMaxSumLineNumber(allFileText);
            Console.WriteLine($"{MAXIMUM_AMOUNT_LINE} {maxSumLineNumber}");
            Console.WriteLine($"{BROKEN_LINES} {linesCalculator.BrokenLinesString}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        finally
        {
            Console.WriteLine(PROGRAM_FINISHED);
            Console.ReadKey();
        }
    }
}