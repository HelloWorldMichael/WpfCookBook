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
using NamespaceDefinition.Contacts;

namespace WpfDataBindings
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Person _person;
		public MainWindow()
		{
			InitializeComponent();
			_person = new Person { Name = "Bart", Age = 10 };
			DataContext = _person;
		}

		private void OnChange(object sender, RoutedEventArgs e)
		{
			_person.Age++;
		}
	}
}
