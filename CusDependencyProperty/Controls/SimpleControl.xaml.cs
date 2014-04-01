using System.Windows;
using System.Windows.Controls;


namespace CusDependencyProperty.Controls
{
	/// <summary>
	/// Interaction logic for SimpleControl.xaml
	/// </summary>
	public partial class SimpleControl : UserControl
	{
		public SimpleControl()
		{
			InitializeComponent();
		}



		public int YearPublished
		{
			get { return (int)GetValue(YearPublishedProperty); }
			set { SetValue(YearPublishedProperty, value); }
		}

		// Using a DependencyProperty as the backing store for YearPublished.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty YearPublishedProperty =
			DependencyProperty.Register("YearPublished", typeof(int), typeof(SimpleControl), new PropertyMetadata(2014));

		
	}
}
