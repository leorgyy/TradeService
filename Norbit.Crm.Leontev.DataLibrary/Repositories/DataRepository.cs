using Norbit.Crm.Leontev.Validators;
using Norbit.Crm.Leontev.DataLibrary.Entitties;
using Norbit.Crm.Leontev.DataLibrary.DbConnection;
using Norbit.Crm.Leontev.DataLibrary.Abstractions;
using LinqToDB;
using Newtonsoft.Json;

namespace Norbit.Crm.Leontev.DataLibrary.Repositories
{
	/// <summary>
	/// Операции с таблицей данных о сделке.
	/// </summary>
    public class DataRepository : IDataRepository
    {
		/// <summary>
		/// Контекст данных.
		/// </summary>
		private readonly TradeDbConnection _tradeDbConnection;

		/// <summary>
		/// Создание репозитория через контекст БД.
		/// </summary>
		/// <param name="tradeDbConnection"> Контекст БД. </param>
		public DataRepository(TradeDbConnection tradeDbConnection)
		{
			_tradeDbConnection = tradeDbConnection;
		}

        /// <summary>
        /// Удаление записи о сделке из таблицы.
        /// </summary>
        /// <param name="id"> Идентификатор записи. </param>
        /// <returns>Количество выполенных строк запроса.</returns>
        public int DeleteRecord(Guid id)
		{
			Validator.CheckNullValue(id);
			Validator.CheckEmptyGuid(id);

			return _tradeDbConnection.Data
				.Where(d => d.Id == id)
				.Delete();
		}

		/// <summary>
		/// Возвращает все записи из таблицы.
		/// </summary>
		/// <returns> Список данных о сделках. </returns>
		public IEnumerable<Data> GetRecords()
		{
			return _tradeDbConnection.Data.ToList();
		}

        /// <summary>
        /// Возвращает запись по идентификатору.
        /// </summary>
        /// <param name="id"> Идентификатор записи. </param>
        /// <returns> Данные о сделке. </returns>
        public Data GetRecord(Guid id)
		{
			Validator.CheckNullValue(id);
			Validator.CheckEmptyGuid(id);

			return _tradeDbConnection.Data.FirstOrDefault(x => x.Id == id);
		}

        /// <summary>
        /// Возвращает сделку по идентификатору записи о сделке.
        /// </summary>
        /// <param name="id"> Идентификатор записи о сделке. </param>
        /// <returns> Сделка.</returns>
        public Trade GetTrade(Guid id)
		{
			Validator.CheckNullValue(id);
			Validator.CheckEmptyGuid(id);

			var data = GetRecord(id);

			Validator.CheckNullValue(data);

			return JsonConvert.DeserializeObject<Trade>(data.Entity);
		}

		/// <summary>
		/// Возвращает список всех сделок пользователя.
		/// </summary>
		/// <param name="userId"> Идентификатор пользователя.</param>
		/// <returns> Список всех сделок пользователя.</returns>
		public IEnumerable<Trade> GetTrades(Guid userId)
		{
			Validator.CheckNullValue(userId);
			Validator.CheckEmptyGuid(userId);

			return _tradeDbConnection.Data
				.Where(d => d.UserId == userId)
				.Select(x => JsonConvert.DeserializeObject<Trade>(x.Entity)).ToList();
		}

        /// <summary>
        /// Вставка записи в таблицу.
        /// </summary>
        /// <param name="data"> Данные о сделке. </param>
        /// <returns>Количество выполенных строк запроса.</returns>
        public int InsertRecord(Data data)
		{
			Validator.CheckNullValue(data);

			return _tradeDbConnection.Insert(data);
		}

        /// <summary>
        /// Обновление записи в таблице.
        /// </summary>
        /// <param name="data"> Данные о сделке. </param>
        /// <returns>Количество выполенных строк запроса.</returns>
        public int UpdateRecord(Data data)
		{
			Validator.CheckNullValue(data);

			return _tradeDbConnection.Update(data);
		}
	}
}
