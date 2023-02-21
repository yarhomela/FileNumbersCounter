using System.Text.RegularExpressions;
using static FileNumbersCounter.Constants.Constants;

namespace FileNumbersCounter.Services
{
    public class DirectoryService
    {
        public string TryToGetValidPath(string inputText)
        {
            bool validPath = Regex.IsMatch(inputText, ABSOLUTE_PATH_REGEX);
            var whileCount = 0;

            while (whileCount < MAX_WHILE_COUNT && !validPath)
            {
                whileCount++;
                Console.WriteLine(INVALID_FILE_PATH_TRY_AGAIN);
                inputText = Console.ReadLine()!;
                validPath = Regex.IsMatch(inputText, ABSOLUTE_PATH_REGEX);
            }

            if (whileCount > MAX_WHILE_COUNT)
            {
                throw new Exception(ERROR_INVALID_FILE_PATH);
            }

            return inputText;
        }
    }
}
