using System;
using System.Windows.Markup;

namespace CusMarkupExtension
{
	public class RandomExtension : MarkupExtension
	{
		private readonly int _from, _to;
		private static readonly Random _random = new Random();
		public RandomExtension(int from, int to)
		{
			_from = from;
			_to = to;
		}

		public RandomExtension(int to) : this(0, to) { }
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			int result = _random.Next(_from, _to);
			return UseFractions ? (double)result : result;
		}

		public bool UseFractions { get; set; }
	}
}
