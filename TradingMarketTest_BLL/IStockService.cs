using TradingMarketTest.Models;

namespace TradingMarketTest_BLL
{
    public interface IStockService
    {
        Task<StockApiResponse> GetStockData();
    }
}
