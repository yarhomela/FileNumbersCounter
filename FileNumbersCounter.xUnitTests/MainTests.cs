using FileNumbersCounter.Services;

namespace FileNumbersCounter.xUnitTests
{
    public class MainTests
    {
        [Fact]
        public async Task CalculatingByValidPathTest()
        {
            var directoryService = new DirectoryService();
            var fileService = new TextFileService();
            var linesCalculator = new LinesCalculatorService();

            string enteredText = "D:\\Development\\My programs\\FileNumbersCounter\\fileNumberExample.txt";

            var filePath = directoryService.TryToGetValidPath(enteredText!);
            var allFileText = await fileService.GetFileTextData(filePath);
            linesCalculator.GetMaxSumLineNumber(allFileText);
        }
    }
}