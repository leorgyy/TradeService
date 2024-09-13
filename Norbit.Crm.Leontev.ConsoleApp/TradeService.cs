using Newtonsoft.Json;
using Norbit.Crm.Leontev.DataLibrary.Entitties;

namespace Norbit.Crm.Leontev.ConsoleApp
{
	/// <summary>
	/// Сервис вывода последней сделки.
	/// </summary>
	public class TradeService
	{
		/// <summary>
		/// Адрес последней сделки.
		/// </summary>
		private static readonly string LastTradeAdress = "Trade/lastTrade";

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
		/// Вывод даты и суммы последней сделки.
		/// </summary>
		public async Task PrintLastTrade()
		{
			var jsonResult = await _httpClient.GetStringAsync(LastTradeAdress);

			var trade = JsonConvert.DeserializeObject<Trade>(jsonResult);

			Console.WriteLine($"Дата сделки: {trade.Created.ToLocalTime().Date}");
			Console.WriteLine($"Сумма сделки: {trade.Amount}");
		}
	}
}