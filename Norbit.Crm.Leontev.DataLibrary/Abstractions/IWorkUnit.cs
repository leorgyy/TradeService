
namespace Norbit.Crm.Leontev.DataLibrary.Abstractions
{
	/// <summary>
	/// Общий контекст репозиториев.
	/// </summary>
	public interface IWorkUnit
	{
		/// <summary>
		/// Репозиторий для таблицы с данными о сделках.
		/// </summary>
		IDataRepository Data { get; }

		/// <summary>
		/// Репозиторий для таблицы пользователей.
		/// </summary>
		IUserRepository User { get; }
	}
}
