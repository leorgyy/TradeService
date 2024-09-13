using Norbit.Crm.Leontev.DataLibrary.Entitties;

namespace Norbit.Crm.Leontev.DataLibrary.Abstractions
{
	/// <summary>
	/// Операции таблицы пользователей.
	/// </summary>
	public interface IUserRepository : IRepository<User>
	{
		/// <summary>
		/// Возвращает пользователя по доменному имени.
		/// </summary>
		/// <param name="domainName"> Доменное имя пользователя. </param>
		/// <returns> Пользователь с совпадающим доменными именем. </returns>
		public User GetUser(string domainName);
	}
}
