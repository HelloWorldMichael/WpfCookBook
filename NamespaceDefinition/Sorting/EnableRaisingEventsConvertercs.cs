using System;
using System.Globalization;
using System.Windows.Data;

namespace NamespaceDefinition.Sorting
{
	public class EnableRaisingEventsConvertercs : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool boolResult;
			if (bool.TryParse(value.ToString(), out boolResult))
			{
				Random random = new Random();
				int nextInt = random.Next(5);
				if (nextInt % 2 == 0)
				{
					return true;
				}

				return false;
			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
