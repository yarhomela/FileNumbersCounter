using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FileNumbersCounter.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var fileService = new TextFileService();
            var directoryService = new DirectoryService();
            var linesCalculator = new LinesCalculatorService();

            var filePath = directoryService.GetPathFromConsole();
            var allFileText = await fileService.GetFileTextData(filePath);
            var maxSumLineNumber = linesCalculator.GetMaxSumLineNumber(allFileText);
        }
    }
}
