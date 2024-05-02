namespace TradingMarketTest.Models
{
    public class StockApiResponse
    {
        public bool Success { get; set; }
        public List<StockItem> Result { get; set; }
    }

    public class StockItem
    {
        public decimal Rate { get; set; }
        public decimal LastPrice { get; set; }
        public string LastPriceStr { get; set; }
        public decimal Hacim { get; set; }
        public string HacimStr { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }
    }
}
