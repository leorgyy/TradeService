using Norbit.Crm.Leontev.DataLibrary.Abstractions;
using Norbit.Crm.Leontev.DataLibrary.DbConnection;
using Norbit.Crm.Leontev.DataLibrary.Repositories;

namespace Norbit.Crm.Leontev.DataLibrary
{
	/// <summary>
	/// Общий контекст репозиториев.
	/// </summary>
	public class WorkUnit : IWorkUnit
	{
		/// <summary>
		/// Репозиторий пользователей.
		/// </summary>
		private IUserRepository _userRepository;

		/// <summary>
		/// Репозиторий данных о сделке.
		/// </summary>
		private IDataRepository _dataRepository;

		/// <summary>
		/// Контекст данных.
		/// </summary>
		private readonly TradeDbConnection _tradeDbConnection;

		/// <summary>
		/// Создает объект через контекст данных.
		/// </summary>
		/// <param name="tradeDbConnection"> Контекст данных. </param>
		public WorkUnit(TradeDbConnection tradeDbConnection)
		{
			_tradeDbConnection = tradeDbConnection;
		}

		/// <summary>
		/// Репозиторий данных о сделке.
		/// </summary>
		public IDataRepository Data
		{
			get
			{
				if (_dataRepository == null)
				{
					_dataRepository = new DataRepository(_tradeDbConnection);
				}

				return _dataRepository;
			}
		}

		/// <summary>
		/// Репозиторий пользователей.
		/// </summary>
		public IUserRepository User
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new UserRepository(_tradeDbConnection);
				}

				return _userRepository;
			}
		}
	}
}
