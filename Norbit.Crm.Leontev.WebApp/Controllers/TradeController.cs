using Microsoft.AspNetCore.Mvc;
using Norbit.Crm.Leontev.DataLibrary.Abstractions;
using Norbit.Crm.Leontev.Validators;
using LinqToDB;

namespace Norbit.Crm.Leontev.WebApp.Controllers
{
    /// <summary>
    /// Контроллер сущности Trade.
    /// </summary>
    [ApiController]
	[Route("api/[controller]")]
	public class TradeController : ControllerBase
	{
		/// <summary>
		/// Общий контекст для репозиториев.
		/// </summary>
		private readonly IWorkUnit _unitOfWork;

		/// <summary>
		/// Создает контроллер по контексту для репозиториев.
		/// </summary>
		/// <param name="unitOfWork"> Общий контекст для репозиториев. </param>
		public TradeController(IWorkUnit unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		/// Возвращает последнюю сделку.
		/// </summary>
		/// <returns>
		/// 200 - сделка найдена
		/// 400 - сделка не найдена. 
		/// </returns>
		[HttpGet("lastTrade")]
		public async Task<IActionResult> GetLastTrade()
		{
			var userDomainName = User.Identity.Name;

			var user = _unitOfWork.User.GetUser(userDomainName);

			Validator.CheckNullValue(user);

			var result = (_unitOfWork.Data.GetTrades(user.Id))
				.Where(x => x.Created <= DateTime.UtcNow)
				.OrderByDescending(x => x.Created)
				.First();

			return result == null
			   ? NotFound("Сделка не найдена")
			   : Ok(result);
		}
	}
}
