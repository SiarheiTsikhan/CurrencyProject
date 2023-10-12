using ApiApplicationCore.Models;
using ApiApplicationDataAccess.Entities;

namespace ApiApplicationCore.Modules
{
    public class MergeDataModule
    {
        public static List<ExchangeRate> MergeData(CurrencyLayerResponse responseEUR, CurrencyLayerResponse responseUSD)
        {
            var exchangeRates = new List<ExchangeRate>();

            foreach (var quotePairEUR in responseEUR.Quotes)
            {
                var currencyPairEUR = quotePairEUR.Key;
                var baseCurrency = currencyPairEUR.Substring(3);

                if (responseUSD.Quotes.TryGetValue($"USD{baseCurrency}", out var quoteUSD))
                {
                    var exchangeRate = new ExchangeRate
                    {
                        ExchangeRateToEUR = quotePairEUR.Value.EndRate,
                        ExchangeRateToUSD = quoteUSD.EndRate,
                        PercentageChangeToUSD = quoteUSD.ChangePercentage,
                        PercentageChangeToEUR = quotePairEUR.Value.ChangePercentage,
                        Currency = new Currency { CurrencyCode = baseCurrency }
                    };

                    exchangeRates.Add(exchangeRate);
                }
            }

            return exchangeRates;
        }
    }
}
