using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Norbit.Crm.Leontev.DataLibrary.Repositories;

namespace Norbit.Crm.Leontev.WebApp
{
	/// <summary>
	/// Web приложение.
	/// </summary>
	public class Program()
	{
		/// <summary>
		/// Точка входа в программу.
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// Запуск api.
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}