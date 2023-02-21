using System.Text;
using static FileNumbersCounter.Constants.Constants;

namespace FileNumbersCounter.Services
{
    public class TextFileService
    {
        public async Task<string> GetFileTextData(string fileName)
        {

            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, DETECT_ENCODING_FROM_BYTE_ORDER_MARKS, MINIMUM_BUFFER_SIZE))
            {
                var readingResult = await streamReader.ReadToEndAsync();

                if (String.IsNullOrWhiteSpace(readingResult))
                {
                    throw new Exception(FILE_IS_EMPTY);
                }

                return readingResult;
            }
        }
    }
}
