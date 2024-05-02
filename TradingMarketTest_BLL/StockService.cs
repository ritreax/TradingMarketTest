using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingMarketTest_BLL
{
    public class StockService : IStockService
    {
        private readonly HttpClient _httpClient;

        public StockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<StockDataViewModel> GetStockData()
        {
            // Fetch data from API using HttpClient
            // Parse the response and return ViewModel
        }
    }
}
