using System;

using Xamarin.Forms;

namespace BitPOS
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			//MainPage = new BitPOS.MainPage();
			MainPage = new NavigationPage(new BitPOS.MainPage());
			//MainPage = new TabsPage ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

