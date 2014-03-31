using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using NamespaceDefinition.Contacts;
using NamespaceDefinition.ForecastData;

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

			//DataContext = new Person { Age = 10, Name = "Bart" };
			//_list.ItemsSource = new ObservableCollection<Person>
			//{
			//	new Person { Name = "Bart", Age = 10 },
			//	new Person { Name = "Homer", Age = 45 },
			//	new Person { Name = "Marge", Age = 35 }
			//};

			//DataContext = Process.GetProcesses();

			//_days.ItemsSource = Enumerable.Range(1, 10);

			var processes = Process.GetProcesses().Where(CanAccess);
			DataContext = processes;
			var view = CollectionViewSource.GetDefaultView(processes);
			view.GroupDescriptions.Add(new PropertyGroupDescription("PriorityClass"));
			view.GroupDescriptions.Add(new PropertyGroupDescription("EnableRaisingEvents"));
		}

		private void OnChange(object sender, RoutedEventArgs e)
		{
			_person.Age++;
		}

		private void OnAdd(object sender, RoutedEventArgs e)
		{
			_people.Add(new Person { Name = "Moe", Age = 40 });
		}

		private void OnGetForecast(object sender, RoutedEventArgs e)
		{
			var data = new List<Forecast>();
			int days = 10;//= (int)_days.SelectedItem;
			var rnd = new Random();
			for (int i = 0; i < days; i++)
			{
				double temp = rnd.NextDouble() * 40 - 10;
				var forecast = new Forecast
				{
					GeneralForecast = (GeneralForecast)rnd.Next(Enum.GetValues(typeof(GeneralForecast)).Length),
					TemperatureLow = temp,
					TemperatureHigh = temp + rnd.NextDouble() * 15,
					Percipitation = rnd.Next(10) > 5 ? rnd.NextDouble() * 10 : 0
				};
				data.Add(forecast);
			}
			DataContext = data;
		}

		//private void OnSort(object sender, RoutedEventArgs e)
		//{
		//	var view = CollectionViewSource.GetDefaultView(DataContext);
		//	view.SortDescriptions.Clear();
		//	if (_sortField.SelectedValue != null)
		//		view.SortDescriptions.Add(new SortDescription((string)_sortField.SelectedValue, _ascending.IsChecked == true ? ListSortDirection.Ascending : ListSortDirection.Descending));
		//}

		//private void OnFilter(object sender, RoutedEventArgs e)
		//{
		//	var view = CollectionViewSource.GetDefaultView(DataContext);
		//	if (string.IsNullOrWhiteSpace(_filterText.Text))
		//		view.Filter = null;
		//	else
		//		view.Filter = obj => ((Process)obj).ProcessName.IndexOf(_filterText.Text, StringComparison.InvariantCultureIgnoreCase) > -1;
		//}

		public static bool CanAccess(Process process)
		{
			try
			{
				var h = process.Handle;
				return true;
			}
			catch
			{
				Trace.WriteLine(string.Format("Process Name: {0}.", process.ProcessName));
				return false;
			}
		}
	}
}
