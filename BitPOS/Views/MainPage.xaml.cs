using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BitPOS
{
	public partial class MainPage : ContentPage
	{
		MainViewModel _viewModel;

		public MainPage ()
		{
			InitializeComponent ();
			_viewModel = new MainViewModel();

			this.BindingContext = _viewModel;
		}

		protected async override void OnAppearing ()
		{
			await _viewModel.UpdateRate ();
			base.OnAppearing ();
		}

		private async void OnButtonClicked(object sender, EventArgs args)
		{
			_viewModel.IsBusy = true;

			try
			{
				var result = await _viewModel.CreateOrder();

				PaymentViewModel viewModel = new PaymentViewModel ();
				viewModel.Address = result.bitcoinAddress;
			
				if (result.bitcoinQrCode.StartsWith("https://"))
				{
					viewModel.ImageUrl = "http://" + result.bitcoinQrCode.Substring(8);
				}
				else
				{
					viewModel.ImageUrl = result.bitcoinQrCode;
				}

				PaymentPage paymentPage = new PaymentPage ();
				paymentPage.BindingContext = viewModel;
				_viewModel.IsBusy = false;

				//Push via nav so we have back button.
				await Navigation.PushAsync (paymentPage);
			}
			catch (Exception ex) 
			{
				await DisplayAlert ("Fail", ex.Message, "Cancel");
			}
		}

		private void OnClearButtonClicked(object sender, EventArgs args)
		{
			_viewModel.Amount = 0;
		}
	}
}