using Norbit.Crm.Leontev.DataLibrary.Entitties;

namespace Norbit.Crm.Leontev.DataLibrary.Abstractions
{
	/// <summary>
	/// Операции таблицы Data.
	/// </summary>
	public interface IDataRepository : IRepository<Data>
	{
		/// <summary>
		/// Возвращает список всех сделок пользователя с введённым идентификатором.
		/// </summary>
		/// <param name="id"> Идентификатор пользователя. </param>
		/// <returns> Список сделок. </returns>
		IEnumerable<Trade> GetTrades(Guid id);

		/// <summary>
		/// Возвращает сделку по идентификатору сделки.
		/// </summary>
		/// <param name="id"> Идентификатор сделки. </param>
		/// <returns> Объект класса сделка. </returns>
		Trade GetTrade(Guid id);
	}
}
