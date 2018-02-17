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

            int wholePart = (int)Math.Truncate(number);
            var smallestSubUnitToConvertTo = languageDetails.CurrenciesToWords[currency].Last().Value; 
            int numOfDigitsToRoundTheResult = (int)Math.Round(Math.Log10(smallestSubUnitToConvertTo));
            var fractionPart = Math.Round(number - wholePart, numOfDigitsToRoundTheResult);

            foreach (var subUnit in languageDetails.CurrenciesToWords[currency])
            {
                var subUnitName = subUnit.Key; 
                var subUnitProportion = subUnit.Value; 

                if (subUnitProportion == 1 && wholePart > 0)
                {
                    result = languageDetails.ConvertNumberToString(wholePart, subUnitName);
                }
                if (subUnitProportion > 1 && fractionPart > 0)
                {
                    int fractionPartToConvert = (int)Math.Truncate(fractionPart * (subUnitProportion));
                    if (fractionPartToConvert != 0)
                    {
                        if (result != string.Empty)
                            result += languageDetails.And;

                        result += languageDetails.ConvertNumberToString(fractionPartToConvert, subUnitName);
                    }

                    fractionPart = Math.Round(fractionPart - fractionPartToConvert * (1 / subUnitProportion), numOfDigitsToRoundTheResult);
                }
            }

            return result;
        }

        
    }
}
