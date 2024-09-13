using Norbit.Crm.Leontev.DataLibrary.Entitties;
using Norbit.Crm.Leontev.Validators;
using Norbit.Crm.Leontev.DataLibrary.DbConnection;
using LinqToDB;
using Norbit.Crm.Leontev.DataLibrary.Abstractions;

namespace Norbit.Crm.Leontev.DataLibrary.Repositories
{
	/// <summary>
	/// Операции над таблицей пользователей.
	/// </summary>
    public class UserRepository : IUserRepository
    {
		/// <summary>
		/// Контекст данных.
		/// </summary>
		private readonly TradeDbConnection _tradeDbConnection;

		/// <summary>
		/// Создает репозиторий по контексту БД.
		/// </summary>
		/// <param name="tradeDbConnection">Контекст БД.</param>
		public UserRepository(TradeDbConnection tradeDbConnection)
		{
			_tradeDbConnection = tradeDbConnection;
		}

        /// <summary>
        /// Удаляет запись о пользователе из таблицы. 
        /// </summary>
        /// <param name="id"> Идентификатор пользователя. </param>
        /// <returns>Количество выполенных строк запроса.</returns>
        public int DeleteRecord(Guid id)
		{
			Validator.CheckNullValue(id);
			Validator.CheckEmptyGuid(id);

			return _tradeDbConnection.Users
				.Where(u => u.Id == id)
				.Delete();
		}

		/// <summary>
		/// Возвращает список пользователей.
		/// </summary>
		/// <returns> Список пользователей.</returns>
		public IEnumerable<User> GetRecords()
		{
			return _tradeDbConnection.Users.ToArray();
		}

		/// <summary>
		/// Возвращает пользователя по идентификатору. 
		/// </summary>
		/// <param name="id"> Идентификатор пользователя.</param>
		/// <returns> Пользователь.</returns>
		public User GetRecord(Guid id)
		{
			Validator.CheckNullValue(id);
			Validator.CheckEmptyGuid(id);

			return _tradeDbConnection.Users.FirstOrDefault(x => x.Id == id);
		}

		/// <summary>
		/// Возвращает пользователя по доменному имени.
		/// </summary>
		/// <param name="domainName">Доменное имя пользователя. </param>
		/// <returns> Пользователь. </returns>
		public User GetUser(string domainName)
		{
			Validator.CheckEmptyString(ref domainName);

			return _tradeDbConnection.Users.FirstOrDefault(u => u.UserDomainName == domainName);
		}

        /// <summary>
        /// Вставка записи о пользователе в таблицу.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        ///<returns>Количество выполенных строк запроса.</returns>
        public int InsertRecord(User user)
		{
			Validator.CheckNullValue(user);

			return _tradeDbConnection.Insert(user);
		}

        /// <summary>
        /// Обновляет запись о пользователе.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        /// <returns>Количество выполенных строк запроса.</returns>
        public int UpdateRecord(User user)
		{
			Validator.CheckNullValue(user);

			return _tradeDbConnection.Update(user);
		}
	}
}