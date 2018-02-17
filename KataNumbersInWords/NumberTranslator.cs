using System;
using System.Linq;

namespace KataNumbersInWords
{
    public class NumberTranslator
    {
        private ILanguageDetails languageDetails;

        public NumberTranslator()
        {
            languageDetails = new EnglishDetails();
        }

        public string Translate(double number, string currency)
        {
            var result = string.Empty;
            var temp = number;
            var smallestSubUnitToConvertTo = languageDetails.CurrenciesToWords[currency].Last().Value; 
            int numOfDigitsToRoundTheResult = (int)Math.Round(Math.Log10(smallestSubUnitToConvertTo));

            foreach (var subUnit in languageDetails.CurrenciesToWords[currency])
            {
                var subUnitName = subUnit.Key; 
                var subUnitProportion = subUnit.Value;

                int fractionPartToConvert = (int)Math.Truncate(temp * (subUnitProportion));

                if (fractionPartToConvert != 0)
                {
                    if (result != string.Empty)
                        result += languageDetails.And;

                    result += languageDetails.ConvertNumberToString(fractionPartToConvert, subUnitName);
                }

                temp = Math.Round(temp - fractionPartToConvert * (1 / subUnitProportion), numOfDigitsToRoundTheResult);
            }

            return result;
        }
    }
}
