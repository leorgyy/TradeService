using LinqToDB.Mapping;

namespace Norbit.Crm.Leontev.DataLibrary.Entitties
{
	/// <summary>
	/// Пользователь.
	/// </summary>
	public class User
	{
		/// <summary>
		/// Id пользователя.
		/// </summary>
		[PrimaryKey]
		public Guid Id { get; set; }

		/// <summary>
		/// Доменное имя пользователя.
		/// </summary>
		[Column(Name = "UserDomainName"), NotNull]
		public string UserDomainName { get; set; }
	}
}
