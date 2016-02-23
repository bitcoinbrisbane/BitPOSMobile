using System;
using System.ComponentModel;

namespace BitPOS
{
	public abstract class BaseViewModel : INotifyPropertyChanged 
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private Boolean _isBusy;

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