using System.Collections.Generic;

namespace KataNumbersInWords
{
    public class EnglishDetails : ILanguageDetails
    {
        public Dictionary<double, string> NumbersToWords { get; }
        public Dictionary<string, IList<KeyValuePair<string, double>>> CurrenciesToWords { get; }
        public string And { get; }
    
        public EnglishDetails()
        {
            NumbersToWords = new Dictionary<double, string>
            {
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"},
                {10, "Ten"},
                {11, "Eleven"},
                {12, "Twelve"},
                {13, "Thirteen"},
                {14, "Fourteen"},
                {15, "Fifteen"},
                {16, "Sixteen"},
                {17, "Seventeen"},
                {18, "Eighteen"},
                {19, "Nineteen"},
                {20, "Twenty" },
                {30, "Thirty" },
                {40, "Forty" },
                {50, "Fifty" },
                {60, "Sixty" },
                {70, "Seventy" },
                {80, "Eighty" },
                {90, "Ninety" }
            };

            CurrenciesToWords = new Dictionary<string, IList<KeyValuePair<string, double>>>
            {
                {"$", new List<KeyValuePair<string, double>>
                    {
                        new KeyValuePair<string, double>("dollar", 1),
                        new KeyValuePair<string, double>("cent", 100)
                    }
                },
                {"#", new List<KeyValuePair<string, double>>
                    {
                        new KeyValuePair<string, double>("dinar", 1),
                        new KeyValuePair<string, double>("dirham", 10),
                        new KeyValuePair<string, double>("kirsh", 100),
                        new KeyValuePair<string, double>("fils", 1000)
                    }
                },
                {"&", new List<KeyValuePair<string, double>>
                    {
                        new KeyValuePair<string, double>("pound", 1),
                        new KeyValuePair<string, double>("shilling", 20),
                        new KeyValuePair<string, double>("pence", 240)
                    }
                }
            };

            And = " and ";
        }

        public string ConvertNumberToString(int number, string subUnitCurrencyWord)
        {
            string result;
            if (number >= 21 && number % 10 != 0)
            {
                var rest = number % 10;
                var tens = number - rest;

                result = NumbersToWords[tens] + ' ' + NumbersToWords[rest] + ' ' + subUnitCurrencyWord + 's';
            }
            else
            {
                result = NumbersToWords[number] + ' ' + subUnitCurrencyWord;

                if (number >= 2)
                    result += 's';
            }

            return result;
        }
    }
}