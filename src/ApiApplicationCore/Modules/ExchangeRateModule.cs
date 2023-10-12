using ApiApplicationDataAccess.Contexts;
using ApiApplicationDataAccess.Entities;

namespace ApiApplicationCore.Modules
{
    public class ExchangeRateModule
    {
        private readonly ExchangeRateDataFetcherModule dataFetcherModule;
        private readonly ApplicationContext dbContext;

        public ExchangeRateModule(ExchangeRateDataFetcherModule dataFetcherModule, ApplicationContext dbContext)
        {
            this.dataFetcherModule = dataFetcherModule;
            this.dbContext = dbContext;
        }

        public void ProcessAndPrintExchangeRates()
        {
            List<ExchangeRate> merge = dataFetcherModule.FetchExchangeRatesAsync().Result;

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.ExchangeRate.AddRange(merge);
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while saving to the database: " + ex.Message);
                    transaction.Rollback();
                    return;
                }
            }

            List<ExchangeRate> exchangeRates = dbContext.ExchangeRate.ToList();
            PrintCurrency(exchangeRates);
        }

        private static void PrintCurrency(List<ExchangeRate> exchangeRates)
        {
            Console.WriteLine("Currency Rate EUR / USD Change EUR / USD");
            foreach (var exchangeRate in exchangeRates)
            {
                Console.WriteLine($"{exchangeRate.Currency.CurrencyCode} " +
                    $"{Math.Round(exchangeRate.ExchangeRateToEUR, 4)} / " +
                    $"{Math.Round(exchangeRate.ExchangeRateToUSD, 4)}  " +
                    $"{Math.Round(exchangeRate.PercentageChangeToEUR, 1)}% / " +
                    $"{Math.Round(exchangeRate.PercentageChangeToUSD, 1)}%");
            }
        }
    }
}
