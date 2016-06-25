using System;

namespace BitPOS
{
	public class SettingsViewModel : BaseViewModel
	{
		private Boolean _isTestnet;

		public Boolean IsTestnet
		{
			set
			{
				_isTestnet = value;
				OnPropertyChanged ("IsTestnet");
			}
			get
			{
				return _isTestnet;
			}
		}


		public void Save()
		{
		}

		public SettingsViewModel ()
		{
		}
	}
}