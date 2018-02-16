using System.Collections.Generic;

namespace KataNumbersInWords
{
    public interface ILanguageDetails
    {
        Dictionary<double, string> NumbersToWords { get; }
        Dictionary<string, IList<KeyValuePair<string, double>>> CurrenciesToWords { get; }
        string And { get; }
        string ConvertNumberToString(int number, string subUnitCurrencyWord);
    }
}