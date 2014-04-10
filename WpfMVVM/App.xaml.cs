using System.Windows;
using NamespaceDefinition.Commands;

namespace WpfMVVM
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			MainWindow mainWindow = new MainWindow();
			mainWindow.DataContext = new ImageData();
			mainWindow.Show();
		}
	}
}
