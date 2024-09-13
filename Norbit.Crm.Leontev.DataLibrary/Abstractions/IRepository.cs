using Microsoft.AspNetCore.Mvc;

namespace Norbit.Crm.Leontev.DataLibrary.Abstractions
{
	/// <summary>
	/// CRUD операции к таблицам в БД.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T>
	{
		/// <summary>
		/// Возвращает все записи в таблице.
		/// </summary>
		/// <returns> Список записей таблицы. </returns>
		IEnumerable<T> GetRecords();

		/// <summary>
		/// Возвращает запись из таблицы по идентификатору.
		/// </summary>
		/// <param name="id"> Идентификатор записи. </param>
		/// <returns> Запись из таблицы. </returns>
		T GetRecord(Guid id);

        /// <summary>
        /// Добавляет сущность <paramref name="entity"/> в таблицу.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <returns>Количество выполенных строк запроса.</returns>
        int InsertRecord(T entity);

        /// <summary>
        /// Обновляет запись.
        /// </summary>
        /// <param name="entity"> Обновляемая сущность.</param>
        /// <returns>Количество выполенных строк запроса.</returns>
        int UpdateRecord(T entity);

        /// <summary>
        /// Удаляет запись из таблицы по идентификатору.
        /// </summary>
        /// <param name="id"> Идентификатор записи. </param>
        /// <returns>Количество выполенных строк запроса.</returns>
        int DeleteRecord(Guid id);
	}
}
