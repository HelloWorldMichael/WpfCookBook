using CusAttachedProperty;
using System;
using System.Collections.Generic;
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

namespace WpfCookBook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Random random = new Random(360);
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//simple.YearPublished++;
		}

		private void RepeatButton_Click(object sender, RoutedEventArgs e)
		{
			//Canvas.SetLeft(_rect, Canvas.GetLeft(_rect) + 5);
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			//RotationManager.SetAngle(_ellipse, random.Next(360));
		}


	}
}
