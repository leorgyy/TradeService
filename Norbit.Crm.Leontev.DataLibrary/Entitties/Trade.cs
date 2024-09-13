namespace Norbit.Crm.Leontev.DataLibrary.Entitties
{
    /// <summary>
    /// Сделка.
    /// </summary>
    public class Trade
    {
        /// <summary>
        /// Сумма сделки.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Дата сделки.
        /// </summary>
        public DateTime Created { get; set; }
    }
}
