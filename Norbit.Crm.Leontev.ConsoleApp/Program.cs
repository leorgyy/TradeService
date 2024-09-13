using System.Configuration;
using System.Runtime.CompilerServices;

namespace Norbit.Crm.Leontev.ConsoleApp
{
	/// <summary>
	/// Консольное приложение.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Ключ для базового url.
		/// </summary>
		private static readonly string BaseAdressKey = "baseAdress";

		/// <summary>
		/// Базовый url адрес.
		/// </summary>
		private static readonly string BaseAdress = ConfigurationManager.AppSettings[BaseAdressKey];

		/// <summary>
		/// Точка входа в программу.
		/// </summary>
		/// <param name="args"></param>
		private static void Main(string[] args)
		{
			PrintLastTrade();
		}

		/// <summary>
		/// Выводит на консоль дату и сумму последней сделке.
		/// </summary>
		private static void PrintLastTrade()
		{
			var httpClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });

			httpClient.BaseAddress = new Uri(BaseAdress);

			var tradeService = new TradeService(httpClient);

			tradeService.PrintLastTrade().GetAwaiter().GetResult();
		}
	}
}
