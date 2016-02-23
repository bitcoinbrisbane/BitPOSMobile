using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BitPOS
{
	public partial class PaymentPage : ContentPage
	{
		private PaymentViewModel _viewModel;

		public PaymentPage ()
		{
			_viewModel = new PaymentViewModel ();
			BindingContext = _viewModel;

			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			_viewModel.StatusColour = "Yellow";
			base.OnAppearing ();
		}

		private async void OnDismissButtonClicked(object sender, EventArgs args)
		{
			Navigation.PopAsync ();
		}

		private async void OnRefreshButtonClicked(object sender, EventArgs args)
		{
			//Button button = (Button)sender;
			await _viewModel.UpdateStatus();
		}
	}
}