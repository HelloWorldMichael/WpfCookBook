using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfResources
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button button = e.Source as Button;
			if (button == null)
			{
				return;
			}

			if (button.Name == "modifyResource")
			{
				LinearGradientBrush brush1 = this.TryFindResource("brush1") as LinearGradientBrush;
				brush1.GradientStops.Add(new GradientStop(Colors.Blue, .5));
			}
			else if (button.Name == "removeResource")
			{
				this.Resources.Remove("brush1");
			}
			else if (button.Name == "replaceResource")
			{
				var brush = new RadialGradientBrush();
				brush.GradientStops.Add(new GradientStop(Colors.Blue, 0));
				brush.GradientStops.Add(new GradientStop(Colors.White, 1));
				this.Resources["brush1"] = brush;
			}
			LinearGradientBrush brush12 = this.TryFindResource("brush1") as LinearGradientBrush;
			Debug.WriteLine(string.Format("brush1 exists? {0}", brush12 == null ? "No" : "Yes"));
		}
	}
}
