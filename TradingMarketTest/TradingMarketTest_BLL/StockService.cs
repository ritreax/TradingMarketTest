using System;
using System.Net.Http;
using System.Threading.Tasks;
using TradingMarketTest.Models;
using System.Net.Http.Formatting;


namespace TradingMarketTest.TradingMarketTest_BLL
{
    public class StockService : IStockService
    {
        private readonly HttpClient _httpClient;

        public StockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<StockApiResponse> GetStockData()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("authorization", "apikey 2KCCX78zHqBkkNFoFH677Q:6c6jE1XBXTQOncvV53ILST");
               // _httpClient.DefaultRequestHeaders.Add("content-type", "application/json");

                HttpResponseMessage response = await _httpClient.GetAsync("https://api.collectapi.com/economy/hisseSenedi");

                response.EnsureSuccessStatusCode(); // Throw on error code.

                if (response.IsSuccessStatusCode)
                {
                    StockApiResponse stockApiResponse = await response.Content.ReadAsAsync<StockApiResponse>();
                    return stockApiResponse;
                }
                else
                {
                    // Handle unsuccessful response here, maybe log or return a default value
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Log or handle the exception
                return null;
            }
        }
    }
}
