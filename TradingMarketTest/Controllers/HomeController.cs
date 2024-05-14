using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TradingMarketTest.Models;
using TradingMarketTest.TradingMarketTest_BLL;
using TradingMarketTest.TradingMarketTest_DAL;

namespace TradingMarketTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStockService _stockService;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IStockService stockService, IConfiguration configuration, AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            _stockService = stockService;
            _configuration = configuration;
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var stockData = await _stockService.GetStockData();
           // await AddStockData(stockData); // AddStockData metodunu çağır

            // Log ekle
            Console.WriteLine("Stock data added to the database.");
            return View();
            //return View(stockData);
            //return View(cryptoData);
        }

        [HttpPost]
        public async Task<IActionResult> AddStockData(StockApiResponse stockData)
        {
            foreach (var item in stockData.Result)
            {
                var existingStock = await _context.trade_stocks.FirstOrDefaultAsync(s => s.Code == item.Code);
                if (existingStock == null)
                {
                    _context.trade_stocks.Add(new TradeStock
                    {
                        Code = item.Code,
                        StockName = item.Text,
                        LastPrice = item.LastPrice,
                        Volume = item.Hacim
                    });
                }
                else
                {
                    existingStock.StockName = item.Text;
                    existingStock.LastPrice = item.LastPrice;
                    existingStock.Volume = item.Hacim;
                }
            }
            await _context.SaveChangesAsync(); // Değişikliklerin asenkron olarak kaydedildiğinden emin olun
            return Ok(); // Başarılı olduğunda Ok() dönülmeli
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string apiUrl = "https://localhost:44347/api/users/register";
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Success");
                    }
                }
            }
            return View(model);
        }

        private async Task<HttpResponseMessage> SendDataToMicroservice(RegisterViewModel model, string url)
        {
            using (var client = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                return response;
            }
        }



        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AnaSayfa()
        {
            return View();  
        }
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
