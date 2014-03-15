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

namespace StandardControls
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
			//MessageBox.Show(string.Format("User: {0}, Comment:{1}{2}", _name.Text, Environment.NewLine, _comment.Text));
		}

		//private void OnLangChanged(object sender, SelectionChangedEventArgs e)
		//{
		//	_keywordList.Items.Clear();
		//	string[] keywords = null;

		//	switch (_langCombo.SelectedIndex)
		//	{
		//		case 0: // C++
		//			keywords = new string[] { "for", "auto", "mutable", "explicit", "class", "volatile" };
		//			break;
		//		case 1: // C#
		//			keywords = new string[] { "while", "var", "implicit", "return", "where", "enum" };
		//			break;
		//		case 2: // VB
		//			keywords = new string[] { "Dim", "Select", "While", "Property", "Function", "If" };
		//			break;
		//		case 3: // F#
		//			keywords = new string[] { "let", "rec", "mutable", "module", "yield", "type" };
		//			break;
		//	}
		//	if (keywords != null)
		//	{
		//		//Array.ForEach(keywords, keyword => _keywordList.Items.Add(keyword));
		//	}
		//}

		private void OnChangeLanugage(object sender, RoutedEventArgs e)
		{
			var item = e.Source as MenuItem;
			//_langCombo.SelectedIndex = Convert.ToInt32(item.Tag);
		}

		private void OnMakeTea(object sender, RoutedEventArgs e)
		{
			var sb = new StringBuilder("Tea: ");
			foreach (RadioButton rb in _teaTypePanel.Children)
				if (rb.IsChecked == true)
				{
					sb.AppendLine(rb.Content.ToString());
					break;
				}
			if (_isSugar.IsChecked == true)
				sb.AppendLine("With sugar");
			if (_isMilk.IsChecked == true)
				sb.AppendLine("With milk");
			if (_isLemon.IsChecked == true)
				sb.AppendLine("With lemon");
			if (_isLemon.IsChecked == true && _isMilk.IsChecked == true)
				sb.AppendLine("Very unusual!");
			MessageBox.Show(sb.ToString(), "Tea Maker");
		}
	}

}
