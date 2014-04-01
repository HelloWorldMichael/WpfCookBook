using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfLayouts
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Loaded += (sender, s) => { InitObjects(); };
		}

		void InitObjects()
		{
			var rnd = new Random();
			const int width = 45, height = 45;
			for (int i = 0; i < 30; i++)
			{
				var shape = rnd.Next(10) > 4 ? (Shape)new Ellipse() :
				(Shape)new Rectangle();
				shape.Stroke = Brushes.Black;
				shape.StrokeThickness = 2;
				shape.Fill = rnd.Next(10) > 4 ? Brushes.Red :
				Brushes.LightBlue;
				shape.Width = width;
				shape.Height = height;
				Canvas.SetLeft(shape, rnd.NextDouble() *
				(_source.ActualWidth - width));
				Canvas.SetTop(shape, rnd.NextDouble() *
				(_source.ActualHeight - height));
				_source.Children.Add(shape);
			}
		}

		private void OnClickCanvas(object sender, MouseButtonEventArgs e)
		{
			//switch (e.ChangedButton)
			//{
			//	case MouseButton.Left:
			//		// add a random ellipse
			//		var circle = new Ellipse
			//		{
			//			Stroke = Brushes.Black,
			//			StrokeThickness = 3,
			//			Fill = Brushes.Red,
			//			Width = 30,
			//			Height = 30
			//		};
			//		var pos = e.GetPosition(_canvas);
			//		Canvas.SetLeft(circle, pos.X - circle.Width / 2);
			//		Canvas.SetTop(circle, pos.Y - circle.Height / 2);
			//		_canvas.Children.Add(circle);
			//		break;

			//	case MouseButton.Right:
			//		var ellipse = e.Source as Ellipse;
			//		if (ellipse != null)
			//			_canvas.Children.Remove(ellipse);
			//		break;
			//}
		}

		private void OnBeginDrag(object sender, MouseButtonEventArgs e)
		{
			var obj = e.Source as Shape;
			if (obj != null)
			{
				DragDrop.DoDragDrop(obj, obj, DragDropEffects.Move);
			}
		}

		private void OnDrop(object sender, DragEventArgs e)
		{
			var element = e.Data.GetData(e.Data.GetFormats()[0]) as UIElement;
			if (element != null)
			{
				_source.Children.Remove(element);
				_target.Children.Add(element);
			}
		}

		private void OnDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(Ellipse).FullName))
				e.Effects = DragDropEffects.Move;
			else
				e.Effects = DragDropEffects.None;
			e.Handled = true;
		}
	}
}
