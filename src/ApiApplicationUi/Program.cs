using ApiApplicationCore.Interfaces;
using ApiApplicationCore.Modules;
using ApiApplicationCore.Services;
using ApiApplicationDataAccess.Contexts;

IRequestService requestService = new RequestService();

var dataFetcherModule = new ExchangeRateDataFetcherModule(requestService);
var dbContext = new ApplicationContext();

var exchangeRateModule = new ExchangeRateModule(dataFetcherModule, dbContext);

exchangeRateModule.ProcessAndPrintExchangeRates();

Console.ReadKey();

