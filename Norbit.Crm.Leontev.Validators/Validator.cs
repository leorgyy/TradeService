namespace Norbit.Crm.Leontev.Validators
{
	/// <summary>
	/// Валидаторы.
	/// </summary>
	public static class Validator
	{
		/// <summary>
		/// Проверяет строку на пустоту null.
		/// </summary>
		/// <param name="inputString">Проверяемая строка.</param>
		/// <exception cref="ArgumentNullException">Пустая строка.</exception>
		public static void CheckEmptyString(ref string inputString)
		{
			if (string.IsNullOrEmpty(inputString))
			{
				throw new ArgumentNullException(nameof(inputString), "Строка не должна быть пустой");
			}
		}

		/// <summary>
		/// Сравнивает <paramref name="value"/> c <paramref name="boundValue"/>.
		/// </summary>
		/// <param name="value">Проверяемое значение.</param>
		/// <param name="boundValue">Нижнее граничное значение.</param>
		/// <exception cref="ArgumentException"><paramref name="value"/> меньше или равен <paramref name="boundValue"/>.</exception>
		public static void CheckBoundValue(double value, double boundValue)
		{
			if (value < boundValue)
			{
				throw new ArgumentException($"Аргумент не должен быть меньше {boundValue}", nameof(value));
			}

			if (value == boundValue)
			{
				throw new ArgumentException($"Аргумент не должен быть равен {boundValue}", nameof(value));
			}
		}

		/// <summary>
		/// Конвертирует <paramref name="inputValue"/> в double.
		/// </summary>
		/// <param name="inputValue">Строка.</param>
		/// <returns>Сконвертированное значение.</returns>
		/// <exception cref="ArgumentException">Неверное значение.</exception>
		public static double CheckIsDouble(string inputValue)
		{
			if (!double.TryParse(inputValue, out var result))
			{
				throw new ArgumentException("Неверно введенные данные: ", nameof(inputValue));
			}

			return result;
		}

		/// <summary>
		/// Конвертирует <paramref name="inputValue"/> в int.
		/// </summary>
		/// <param name="inputValue"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">Неверное значение.</exception>
		public static int CheckIsInt(string inputValue)
		{
			if (!int.TryParse(inputValue, out var result))
			{
				throw new ArgumentException("Неверно введенные данные: ", nameof(inputValue));
			}

			return result;
		}

		/// <summary>
		/// Конвертирует <paramref name="inputValue"/> в DateTime. 
		/// </summary>
		/// <param name="inputValue"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">Неверное значение.</exception>
		public static DateTime CheckIsDate(string inputValue)
		{
			if (!DateTime.TryParse(inputValue, out var result))
			{
				throw new ArgumentException("Неверно введенные данные: ", nameof(inputValue));
			}

			return result;
		}

		/// <summary>
		/// Проверяет вхождение значения в границах диапазона.
		/// </summary>
		/// <param name="value">Проверяемое значение.</param>
		/// <param name="bottomBorder">Нижняя граница диапазона.</param>
		/// <param name="topBorder">Верхняя граница диапазона.</param>
		/// <exception cref="ArgumentOutOfRangeException">Значение вне границ заданного диапазона.</exception>
		public static void CheckValueInRange(double value, double bottomBorder, double topBorder)
		{
			if (value < bottomBorder || value > topBorder)
			{
				throw new ArgumentOutOfRangeException(nameof(value), "Значение не входит в заданные границы.");
			}
		}

		/// <summary>
		/// Проверяет значение на null.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value">Проверяемое значение.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> равен null.<exception>
		public static void CheckNullValue <T> (T value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value), "Аргумент не может быть null");
			}
		}

        /// <summary>
        /// Проверяет Guid на пустое значение.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <exception cref="ArgumentNullException">Аргумент не должен быть пустым.</exception>
        public static void CheckEmptyGuid(Guid value)
		{
            if (value == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(value), "Аргумент не должен быть пустым.");
            }
        }
	}
}
