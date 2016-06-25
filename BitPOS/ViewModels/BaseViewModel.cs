using System;
using System.ComponentModel;

namespace BitPOS
{
	public abstract class BaseViewModel : INotifyPropertyChanged 
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private Boolean _isBusy;
		private Boolean _allowUserInteration;

		public Boolean IsBusy
		{
			set
			{
				_isBusy = value;
				OnPropertyChanged ("IsBusy");
			}
			get
			{
				return _isBusy;
			}
		}

		public Boolean AllowUserInteration
		{
			set
			{
				_allowUserInteration = value;
				OnPropertyChanged ("AllowUserInteration");
			}
			get
			{
				return _allowUserInteration;
			}
		}

		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}