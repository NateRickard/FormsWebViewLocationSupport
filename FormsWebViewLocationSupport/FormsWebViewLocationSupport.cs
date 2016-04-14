using System;

using Xamarin.Forms;

namespace FormsWebViewLocationSupport
{
	public class App : Application
	{
		public App ()
		{
			var webView = new WebView ();
			webView.HeightRequest = 500;
			webView.Source = "https://maps.google.com";

			//iOS: see http://stackoverflow.com/questions/26631417/allowing-location-access-inside-uiwebview
			//	You must set the NSLocationWhenInUseUsageDescription key in info.plist in order to get prompted.

			//Android: We've created a custom renderer which can be found in the Android project

			// The root page of your application
			var content = new ContentPage {
				Title = "Forms WebView Location Support",
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.StartAndExpand,
					Children = {
						webView
					}
				}
			};

			MainPage = new NavigationPage (content);
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