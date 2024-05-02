using TradingMarketTest.Models;

namespace TradingMarketTest.TradingMarketTest_BLL
{
    public interface IStockService
    {
        Task<StockApiResponse> GetStockData();
    }
}
