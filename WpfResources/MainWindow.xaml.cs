using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

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

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			// If the resource has been marked with a Build Actionof Content, then the similar looking 
			// Application.GetContentStreammethod should be used instead.	
			var resource = Application.GetResourceStream(new Uri("books.xml", UriKind.Relative));

			var books = from book in XElement.Load(resource.Stream).Elements("Book")
						orderby (string)book.Attribute("Author")
						select new
						{
							Name = book.Attribute("Name"),
							Author = book.Attribute("Author")
						};

			foreach(var book in books)
			{
				//_text.Text += book + Environment.NewLine;
			}
		}
	}
}
