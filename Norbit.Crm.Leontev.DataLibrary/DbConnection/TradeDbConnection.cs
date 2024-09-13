using LinqToDB;
using LinqToDB.Data;
using Norbit.Crm.Leontev.DataLibrary.Entitties;

namespace Norbit.Crm.Leontev.DataLibrary.DbConnection
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    public class TradeDbConnection : DataConnection
    {
        /// <summary>
        /// Подключение к БД.
        /// </summary>
        /// <param name="configuration">Конфигурация приложения.</param>
        public TradeDbConnection(DataOptions<TradeDbConnection> options)
        : base(options.Options)
        {
        }

        /// <summary>
        /// Таблица пользователей.
        /// </summary>
        public ITable<User> Users => this.GetTable<User>();

        /// <summary>
        /// Таблица данных пользователей.
        /// </summary>
        public ITable<Data> Data => this.GetTable<Data>();
    }
}
