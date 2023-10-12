using ApiApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplicationCore.Interfaces
{
    public interface IRequestService
    {
        public Task<CurrencyLayerResponse> SearchAsync(string str);
    }
}
