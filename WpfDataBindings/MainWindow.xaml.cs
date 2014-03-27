using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using NamespaceDefinition.Contacts;

namespace WpfDataBindings
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Person _person;
		List<Person> _people;
		public MainWindow()
		{
			InitializeComponent();
			//_person = new Person { Name = "Bart", Age = 10 };
			//DataContext = _person;

			//_people = new List<Person> 
			//{
			//	new Person { Name = "Bart", Age = 10 },
			//	new Person { Name = "Homer", Age = 45 },
			//	new Person { Name = "Marge", Age = 35 },
			//	new Person { Name = "Lisa", Age = 12 },
			//	new Person { Name = "Maggie", Age = 1 }
			//};

			//_list.ItemsSource = _people;

			DataContext = new Person { Age = 10, Name = "Bart" };
			_list.ItemsSource = new ObservableCollection<Person>
			{
				new Person { Name = "Bart", Age = 10 },
				new Person { Name = "Homer", Age = 45 },
				new Person { Name = "Marge", Age = 35 }
			};
		}

		private void OnChange(object sender, RoutedEventArgs e)
		{
			_person.Age++;
		}

		private void OnAdd(object sender, RoutedEventArgs e)
		{
			_people.Add(new Person { Name = "Moe", Age = 40 });
		}
	}
}
