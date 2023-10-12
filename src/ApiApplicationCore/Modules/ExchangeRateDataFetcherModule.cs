using ApiApplicationCore.Constants;
using ApiApplicationCore.Interfaces;
using ApiApplicationDataAccess.Entities;

namespace ApiApplicationCore.Modules
{
    public class ExchangeRateDataFetcherModule
    {
        private readonly IRequestService requestService;

        public ExchangeRateDataFetcherModule(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        public async Task<List<ExchangeRate>> FetchExchangeRatesAsync()
        {
            try
            {
                var responseEur = await requestService.SearchAsync(Common.currencyEur);
                var responseUsd = await requestService.SearchAsync(Common.currencyUsd);

                return MergeDataModule.MergeData(responseEur, responseUsd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching exchange rates: " + ex.Message);
                return new List<ExchangeRate>();
            }
        }
    }
}
