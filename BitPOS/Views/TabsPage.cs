using System;

using Xamarin.Forms;

namespace BitPOS
{
	public class TabsPage : TabbedPage
	{
		public TabsPage ()
		{
			this.Children.Add (new MainPage ());
			this.Children.Add (new SettingsPage());
			this.Children.Add (new HistoryPage());
		}
	}
}