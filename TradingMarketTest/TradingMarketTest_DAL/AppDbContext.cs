using Microsoft.EntityFrameworkCore;
using TradingMarketTest.Models;

namespace TradingMarketTest.TradingMarketTest_DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TradeStock> trade_stocks { get; set; }
    }
}
