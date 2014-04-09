using System.ComponentModel;

namespace NamespaceDefinition.Commands
{
	public class ImageData : ObservableObject
	{
		public string ImagePath { get; private set; }
		public ImageData(string path)
		{
			ImagePath = path;
		}
		double _zoom = 1.0;
		public double Zoom
		{
			get { return _zoom; }
			set
			{
				SetProperty<double>(ref _zoom, value);
			}
		}
		
	}
}
