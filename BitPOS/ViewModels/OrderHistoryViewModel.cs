using System;
using System.Collections.ObjectModel;

namespace BitPOS
{
	public class OrderHistoryViewModel : BaseViewModel
	{
		public ObservableCollection<IOrder> OrderHistory { get; set; }

		public ObservableCollection<String> Orders { get; set; }

		public OrderHistoryViewModel ()
		{
		}
	}
}