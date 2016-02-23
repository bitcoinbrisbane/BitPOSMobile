using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;

namespace BitPOS
{
	public class PaymentViewModel : BaseViewModel
	{
		private Decimal _amount;
		private String _address;
		private String _imageUrl;
		private String _status;
		private String _statusColour;
		private String _encodedOrderId;

		public Decimal Amount
		{
			set
			{
				_amount = value;
				OnPropertyChanged ("Amount");
			}
			get
			{
				return _amount;
			}
		}

		public String Address
		{
			set
			{
				_address = value;
				OnPropertyChanged ("Address");
			}
			get
			{
				return _address;
			}
		}

		public String ImageUrl 
		{
			set
			{
				_imageUrl = value;
				OnPropertyChanged ("ImageUrl");
			}
			get
			{
				return _imageUrl;
			}
		}

		public String Status 
		{
			set
			{
				_status = value;
				OnPropertyChanged ("Status");
			}
			get
			{
				return _status;
			}
		}

		public String StatusColour
		{
			set
			{
				_statusColour = value;
				OnPropertyChanged ("StatusColour");
			}
			get
			{
				return _statusColour;
			}
		}

		public String EncodedOrderId
		{
			set
			{
				_encodedOrderId = value;
				OnPropertyChanged ("EncodedOrderId");
			}
			get
			{
				return _encodedOrderId;
			}
		}

		public PaymentViewModel ()
		{
		}

		public async Task<Models.BitPOS.OrderResponse> CreateOrder()
		{
			BitPOSClient client = new BitPOSClient (Settings.Instance.Key, Settings.Instance.Password, Settings.Instance.TestNet);
			Models.BitPOS.OrderResponse orderResponse = await client.CreateOrder (Convert.ToInt32(Amount * 100));

			return orderResponse;
		}

		public async Task UpdateStatus()
		{
			BitPOSClient client = new BitPOSClient (Settings.Instance.Key, Settings.Instance.Password, Settings.Instance.TestNet);
			String statusResponse = await client.GetOrderStatus (this.EncodedOrderId);

			Status = "Unpaid";
		}
	}
}