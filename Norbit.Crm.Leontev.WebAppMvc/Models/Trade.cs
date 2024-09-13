namespace Norbit.Crm.Leontev.WebAppMvc.Models
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
