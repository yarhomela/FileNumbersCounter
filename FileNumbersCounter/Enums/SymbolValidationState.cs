
namespace FileNumbersCounter.Enums
{
    public enum SymbolValidationState
    {
        None = 0,
        IsNumber = 1,
        IsDot = 2,
        IsComma = 3,
        IsEmptyOrSpace = 4,
        IsNewLine = 5,
        IsInvalidNumber = 6,
    }
}
