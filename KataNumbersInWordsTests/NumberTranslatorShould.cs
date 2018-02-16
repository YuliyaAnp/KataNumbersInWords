using NUnit.Framework;
using FluentAssertions;
using KataNumbersInWords;

namespace KataNumbersInWordsTests
{
    public class NumberTranslatorShould
    {
        [TestCase(1.0, "$", "One dollar")]
        [TestCase(2.0, "$", "Two dollars")]
        [TestCase(10.0, "$", "Ten dollars")]
        [TestCase(19.0, "$", "Nineteen dollars")]
        [TestCase(21.0, "$", "Twenty One dollars")]
        [TestCase(42.0, "$", "Forty Two dollars")]
        [TestCase(25.30, "$", "Twenty Five dollars and Thirty cents")]
        [TestCase(99.99, "$", "Ninety Nine dollars and Ninety Nine cents")]
        [TestCase(0.50, "$", "Fifty cents")]
        [TestCase(0.1, "$", "Ten cents")]
        [TestCase(1.01, "$", "One dollar and One cent")]
        [TestCase(99.01, "$", "Ninety Nine dollars and One cent")]
        public void ReturnCorrespondingWordsToInputNumberAndCurrency(double number, string currencySymbol, string words)
        {
            var numberTranslator = new NumberTranslator();
            string actual = numberTranslator.Translate(number, currencySymbol);

            actual.Should().Be(words);
        }

    }
}
