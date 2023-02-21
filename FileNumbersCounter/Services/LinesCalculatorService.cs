using FileNumbersCounter.Enums;
using System.Text.RegularExpressions;
using static FileNumbersCounter.Constants.Constants;

namespace FileNumbersCounter.Services
{
    public class LinesCalculatorService
    {
        public string BrokenLinesString { get; set; }
        public int MaxSumLineNumber { get; set; }

        public char[] NumbersSymbols = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public LinesCalculatorService()
        {
            BrokenLinesString = String.Empty;
        }

        public int GetMaxSumLineNumber(string textFileData)
        {
            var brokenLines = new List<int>();

            int lineIndex = 1;

            double maxLineSum = 0;
            double currentLineSum = 0;

            string validStringNumber = String.Empty;

            for (int i = 0; i < textFileData.Length;)
            {
                var currentSymbol = textFileData[i];
                var symbolState = GetSymbolValidationState(currentSymbol);

                bool isNumberEmpty = String.IsNullOrWhiteSpace(validStringNumber);
                bool isLastCharIsNumber = isNumberEmpty ? false : IsNumberSymbol(validStringNumber.LastOrDefault());

                var nextNewLineIndex = textFileData.Length - 1;
                if (i + 1 < textFileData.Length)
                {
                    nextNewLineIndex = textFileData.IndexOf(NEWLINE_CHAR, i + 1) + 1;
                }

                if (symbolState == SymbolValidationState.IsNumber)
                {
                    validStringNumber += currentSymbol;
                    i++;
                    continue;
                }

                if (symbolState == SymbolValidationState.IsDot && isLastCharIsNumber)
                {
                    validStringNumber += COMMA_CHAR;
                    i++;
                    continue;
                }

                if (symbolState == SymbolValidationState.IsEmptyOrSpace)
                {
                    i++;
                    continue;
                }

                if (symbolState == SymbolValidationState.IsInvalidNumber)
                {
                    brokenLines.Add(lineIndex);
                    validStringNumber = String.Empty;
                    currentLineSum = 0;
                    lineIndex++;
                    i = nextNewLineIndex;
                    continue;
                }

                if (symbolState == SymbolValidationState.IsComma && isLastCharIsNumber)
                {
                    var doubleNumber = GetDoubleNumber(validStringNumber);
                    currentLineSum += doubleNumber;
                    validStringNumber = String.Empty;
                    i++;
                    continue;
                }

                if ((symbolState == SymbolValidationState.IsDot || symbolState == SymbolValidationState.IsComma) && !isLastCharIsNumber)
                {
                    brokenLines.Add(lineIndex);
                    validStringNumber = String.Empty;
                    currentLineSum = 0;
                    lineIndex++;
                    i = nextNewLineIndex;
                    continue;
                }

                if (symbolState == SymbolValidationState.IsNewLine && isLastCharIsNumber)
                {
                    var doubleNumber = GetDoubleNumber(validStringNumber);
                    currentLineSum += doubleNumber;
                    validStringNumber = String.Empty;

                    bool isMoreThanOld = currentLineSum > maxLineSum;

                    maxLineSum = isMoreThanOld ? currentLineSum : maxLineSum;
                    MaxSumLineNumber = isMoreThanOld ? lineIndex : MaxSumLineNumber;

                    currentLineSum = 0;
                    lineIndex++;
                    i++;
                    continue;
                }

                if (symbolState == SymbolValidationState.IsNewLine && !isLastCharIsNumber)
                {
                    validStringNumber = String.Empty;
                    currentLineSum = 0;
                    lineIndex++;
                    i++;
                }
            }

            BrokenLinesString = String.Join(", ", brokenLines);

            return MaxSumLineNumber;

        }

        private SymbolValidationState GetSymbolValidationState(char symbol)
        {

            if (IsNumberSymbol(symbol))
            {
                return SymbolValidationState.IsNumber;
            }

            if (symbol == DOT_CHAR)
            {
                return SymbolValidationState.IsDot;
            }

            if (symbol == COMMA_CHAR)
            {
                return SymbolValidationState.IsComma;
            }

            if (symbol == EMPTY_CHAR || symbol == CARRIAGE_CHAR || symbol == TAB_CHAR)
            {
                return SymbolValidationState.IsEmptyOrSpace;
            }

            if (symbol == NEWLINE_CHAR)
            {
                return SymbolValidationState.IsNewLine;
            }

            return SymbolValidationState.IsInvalidNumber;
        }

        private bool IsNumberSymbol(char symbol)
        {
            return NumbersSymbols.Contains(symbol);
        }

        private double GetDoubleNumber(string stringNumber)
        {
            bool isValid = Regex.IsMatch(stringNumber, NUMBERS_WITH_COMMA_REGEX);

            if (isValid)
            {
                return Double.Parse(stringNumber);
            }
            return default(double);
        }
    }
}
