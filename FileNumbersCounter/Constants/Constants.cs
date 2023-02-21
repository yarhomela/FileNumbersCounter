
namespace FileNumbersCounter.Constants
{
    public partial class Constants
    {
        public const int MAX_WHILE_COUNT = 5;

        public const string PROJECT_DESCRIPTION = "Project: FileNumbersCounter \n Enter path to your text file \n " +
            "Get the line number with the maximum amount. \n Broken lines will be output separately.";

        public const string PRESS_ANY_KEY_TO_START = "Press any key to start: ";
        public const string PLEASE_ENTER_FILE_PATH = "Please, enter file path: ";
        public const string MAXIMUM_AMOUNT_LINE = "Maximum amount line - ";
        public const string BROKEN_LINES = "Broken lines: ";

        public const string INVALID_FILE_PATH_TRY_AGAIN = "Invalid file path! Please enter document path again:";
        public const string ERROR_INVALID_FILE_PATH = "Error: Invalid file path!";
        public const string FILE_IS_EMPTY = "Error: File is empty!";

        public const string PROGRAM_FINISHED = "Program finished! Press any key for exit!";

        public const string ABSOLUTE_PATH_REGEX = "([a-zA-Z]:(\\w+)*\\[a-zA-Z0_9]+)?.txt";
        public const string NUMBERS_WITH_DOT_REGEX = "^(\\d+\\.)?\\d+$";
        public const string NUMBERS_WITH_COMMA_REGEX = "^(\\d+\\,)?\\d+$";
        public const string NUMBERS_WITH_DOTS_COMMA_REGEX = "^[0-9.,]+$";

        public const int MINIMUM_BUFFER_SIZE = 128;
        public const bool DETECT_ENCODING_FROM_BYTE_ORDER_MARKS = true;

        public const char DOT_CHAR = '.';
        public const char COMMA_CHAR = ',';
        public const char EMPTY_CHAR = ' ';
        public const char CARRIAGE_CHAR = '\r';
        public const char TAB_CHAR = '\t';
        public const char NEWLINE_CHAR = '\n';
    }
}
