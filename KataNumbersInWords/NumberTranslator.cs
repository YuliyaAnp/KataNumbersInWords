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

          //  var howManySubUnitsInCurrency = languageDetails.CurrenciesToWords[currency].Count;

            int wholePart = (int)Math.Truncate(number);
            var smallestSubUnitToConvertTo = languageDetails.CurrenciesToWords[currency].Last().Value;
            int numOfDigitsToRoundTheResult = (int)Math.Round(Math.Log10(1 / smallestSubUnitToConvertTo));

            int fractionPart = (int)(Math.Round(number - wholePart, numOfDigitsToRoundTheResult) * Math.Pow(10, numOfDigitsToRoundTheResult)); // if we have 0.11 then we will have fractionPart = 11 (11 cents)

            foreach (var subUnit in languageDetails.CurrenciesToWords[currency])
            {
                var subUnitName = subUnit.Key; //"dollar" or "cent"
                var subUnitProportion = subUnit.Value; // "1" or "0.01"

                if (subUnitProportion == 1 && wholePart > 0)
                {
                    result = languageDetails.ConvertNumberToString(wholePart, subUnitName);
                    if (fractionPart > 0)
                        result += languageDetails.And;
                }
                if (subUnitProportion < 1 && fractionPart > 0)
                {
                    result += languageDetails.ConvertNumberToString(fractionPart, subUnitName);
                }
            }

            //if (wholePart > 0)
            //{
            //    result = languageDetails.ConvertNumberToString(wholePart, languageDetails.CurrenciesToWords[currency][0].Key);

            //    if (fractionPart > 0)
            //        result += languageDetails.And;
            //}

            //if (fractionPart > 0)
            //{
            //    result += languageDetails.ConvertNumberToString(fractionPart, languageDetails.CurrenciesToWords[currency][1].Key);
            //}

            return result;
        }

        
    }
}
