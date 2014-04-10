using System.ComponentModel;
using System.Windows.Input;

namespace NamespaceDefinition.Commands
{
	public class ImageData : ObservableObject
	{
		string _imagePath;
		double _zoom = 1.0;
		ICommand _openImageFileCommand, _zoomCommand;

		public ImageData()
		{
			_openImageFileCommand = new OpenImageFileCommand(this);
			_zoomCommand = new ZoomCommand(this);
		}

		public double Zoom
		{
			get { return _zoom; }
			set
			{
				SetProperty<double>(ref _zoom, value);
			}
		}

		public string ImagePath
		{
			get { return _imagePath; }
			set
			{
				SetProperty<string>(ref _imagePath, value);
			}
		}

		public ICommand OpenImageFileCommand
		{
			get { return _openImageFileCommand; }
		}

		public ICommand ZoomCommand
		{
			get { return _zoomCommand; }
		}
		
	}
}
