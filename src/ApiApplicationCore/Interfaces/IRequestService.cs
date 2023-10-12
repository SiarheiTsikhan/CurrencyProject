using ApiApplicationCore.Models;

namespace ApiApplicationCore.Interfaces
{
    public interface IRequestService
    {
        public Task<CurrencyLayerResponse> SearchAsync(string str);
    }
}
