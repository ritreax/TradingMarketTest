using System.ComponentModel.DataAnnotations;

namespace TradingMarketTest.Models
{
    public class TradeStock
    {
        [Key] 
        public string Code { get; set; }
        public string StockName { get; set; }
        public decimal LastPrice { get; set; }
        public decimal Volume { get; set; }
    }
}
