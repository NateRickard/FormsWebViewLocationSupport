using Android;
using Android.App;
using Android.Content;
using Android.Webkit;
using FormsWebViewLocationSupport.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: UsesPermission (Name = Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission (Name = Manifest.Permission.Internet)]

[assembly: ExportRenderer (typeof (Xamarin.Forms.WebView), typeof (LocationWebViewRenderer))]

namespace FormsWebViewLocationSupport.Droid
{
	public class LocationWebViewRenderer : WebViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.WebView> e)
		{
			base.OnElementChanged (e);

			//initial setup
			if (e.OldElement == null) {
				Control.Settings.SetGeolocationEnabled (true);
			}
		}

		protected override FormsWebChromeClient GetFormsWebChromeClient ()
		{
			return new MyWebChromeClient (base.Context);
		}
	}


	public class MyWebChromeClient : FormsWebChromeClient
	{
		private readonly Context _context;

		public MyWebChromeClient (Context context)
		{
			_context = context;
		}

		public override void OnGeolocationPermissionsShowPrompt (string origin, GeolocationPermissions.ICallback callback)
		{
			const bool remember = false;
			var builder = new AlertDialog.Builder (_context);

			builder.SetTitle ("Location")
				.SetMessage (string.Format ("{0} would like to use your current location", origin))
				.SetPositiveButton ("Allow", (sender, args) => callback.Invoke (origin, true, remember))
				.SetNegativeButton ("Disallow", (sender, args) => callback.Invoke (origin, false, remember));

			var alert = builder.Create ();
			alert.Show ();
		}
	}
}