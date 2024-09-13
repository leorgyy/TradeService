using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using Norbit.Crm.Leontev.WebAppMvc.Models;

namespace Norbit.Crm.Leontev.WebAppMvc.Controllers
{
    /// <summary>
    /// Контроллер отображения сделок.
    /// </summary>
    public class TradeController : Controller
    {
        /// <summary>
        /// Базовый адрес.
        /// </summary>
        private static readonly string BaseAddress = "https://localhost:44329/api";
        
        /// <summary>
        /// Домашняя страница.
        /// </summary>
        /// <returns></returns>
        public IActionResult Home()
        {
            return View();
        }

        /// <summary>
        /// Получает последнюю сделку.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LastTrade()
        {
            var httpClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });

            httpClient.BaseAddress = new Uri(BaseAddress);

            var tradeService = new TradeService(httpClient);

            return View(tradeService.GetLastTrade().GetAwaiter().GetResult());
        }
    }
}
