using ApiApplicationCore.Constants;
using ApiApplicationCore.Interfaces;
using ApiApplicationCore.Models;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplicationCore.Services
{
    public class RequestService: IRequestService
    {
        public async Task<CurrencyLayerResponse> SearchAsync(string currencyName)
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string dateBefore = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");

            var queryParameters = new
            {
                start_date = dateBefore,
                end_date = dateToday,
                access_key = Common.accesKey,
                currencies = Common.allCurrencies,
                source = currencyName,
            };

            var response = await Common.endpoint
                .AppendPathSegments(Common.changeEndpoint)
                .SetQueryParams(queryParameters)
                .GetJsonAsync<CurrencyLayerResponse>();

            return response;
        }
    }
}
