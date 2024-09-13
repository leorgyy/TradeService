using LinqToDB.Mapping;

namespace Norbit.Crm.Leontev.DataLibrary.Entitties
{
	/// <summary>
	/// Данные сделки.
	/// </summary>
	public class Data
	{
		/// <summary>
		/// Id сделки.
		/// </summary>
		[PrimaryKey]
		public Guid Id { get; set; }

		/// <summary>
		/// Id пользователя.
		/// </summary>
		[Column(Name ="UserId"), NotNull]
		public Guid UserId { get; set; }

		[Association(ThisKey = "UserId", OtherKey = "Id", CanBeNull = false)]
		public User User { get; set; }

		/// <summary>
		/// Сериализованное представление сделки.
		/// </summary>
		public string Entity { get; set; }
	}
}
