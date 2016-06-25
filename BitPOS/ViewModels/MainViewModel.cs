using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BitPOS
{
	public class MainViewModel : BaseViewModel
	{
		private Decimal _amount;
		private Decimal _bitcoinAmount;
		private Decimal _rate;
		private String _reference;

		public Decimal Amount
		{
			set
			{
				_amount = value;
				if (_rate > 0) 
				{
					BitcoinAmount = _amount / _rate;
				}
				OnPropertyChanged ("Amount");
			}
			get
			{
				return _amount;
			}
		}

		public Decimal Rate
		{
			set
			{
				_rate = value;
				OnPropertyChanged ("Rate");
			}
			get
			{
				return _rate;
			}
		}

		public Decimal BitcoinAmount
		{
			set
			{
				_bitcoinAmount = value;
				OnPropertyChanged ("BitcoinAmount");
			}
			get
			{
				return _bitcoinAmount;
			}
		}

		public String Reference
		{
			set
			{
				_reference = value;
				OnPropertyChanged ("Reference");
			}
			get
			{
				return _reference;
			}
		}

		public MainViewModel ()
		{
		}

		public async Task<Models.BitPOS.OrderResponse> CreateOrder()
		{
			BitPOSClient client = new BitPOSClient (Settings.Instance.Key, Settings.Instance.Password, Settings.Instance.IsTestNet);
			Models.BitPOS.OrderResponse orderResponse = await client.CreateOrder (Convert.ToInt32(Amount * 100), this.Reference, "");

			return orderResponse;
		}

		public async Task UpdateRate()
		{
			BitPOS.IExchangeRateClient client = new BitPOSClient (Settings.Instance.Key, Settings.Instance.Password, Settings.Instance.IsTestNet);

			this.Rate = 600;
			//this.Rate = await client.GetExchangeRateAsync ("AUD");
		}
	}
}