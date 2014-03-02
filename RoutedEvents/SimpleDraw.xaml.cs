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
using System.Diagnostics;

namespace RoutedEvents
{
	/// <summary>
	/// Interaction logic for SimpleDrawe.xaml
	/// </summary>
	public partial class SimpleDraw : UserControl
	{
		Point _pos;
		bool _isDrawing;
		Brush _stroke = Brushes.Black;
		public SimpleDraw()
		{
			InitializeComponent();
		}

		private void OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			var rectangle = e.Source as Rectangle;

			if (rectangle != null)
			{
				_stroke = rectangle.Fill;
			}
			else
			{
				_isDrawing = true;
				_pos = e.GetPosition(_root);
				_root.CaptureMouse();
			}
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (_isDrawing)
			{
				Line line = new Line();
				line.X1 = _pos.X;
				line.Y1 = _pos.Y;
				_pos = e.GetPosition(_root);
				line.X2 = _pos.X;
				line.Y2 = _pos.Y;
				line.Stroke = _stroke;
				line.StrokeThickness = 1;
				Debug.WriteLine(string.Format("({0},{1} -----> ({2},{3}))", line.X1, line.Y1, line.X2, line.Y2));
				_root.Children.Add(line);
			}
		}

		private void OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			_isDrawing = false;
			_root.ReleaseMouseCapture();
		}
	}
}
