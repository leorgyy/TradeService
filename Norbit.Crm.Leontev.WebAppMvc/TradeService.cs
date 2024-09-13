using Newtonsoft.Json;
using Norbit.Crm.Leontev.WebAppMvc.Models;

namespace Norbit.Crm.Leontev.WebAppMvc
{
	/// <summary>
	/// Сервис вывода последней сделки.
	/// </summary>
	public class TradeService
	{
		/// <summary>
		/// Адрес последней сделки.
		/// </summary>
		private static readonly string LastTradeAddress = "https://localhost:44329/api/Trade/lastTrade";

		/// <summary>
		/// Клиент.
		/// </summary>
		private readonly HttpClient _httpClient;

		/// <summary>
		/// Инициализирует сервис по клиенту.
		/// </summary>
		/// <param name="httpClient"> Клиент.</param>
		public TradeService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		/// <summary>
		/// Получает данные последней сделки.
		/// </summary>
		public async Task<Trade> GetLastTrade()
		{
			var jsonResult = await _httpClient.GetStringAsync(LastTradeAddress);

            var trade = JsonConvert.DeserializeObject<Trade>(jsonResult);

			return trade;
		}
	}
}