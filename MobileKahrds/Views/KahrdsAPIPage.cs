using System;
using Xamarin.Forms;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MobileKahrds
{

	public class KahrdsAPIPage : ContentPage
	{
		ListView lv;
		Label l;

		public KahrdsAPIPage ()
		{
			l = new Label { Text = "API Calls"};
			l.FontSize =  Device.GetNamedSize(NamedSize.Large, typeof(Label));
			l.FontAttributes = FontAttributes.Bold;

			var a = new Button { Text = "Login  getSessionToken" };
			a.Clicked += async (sender, e) => {
				var sv = new KahrdsWebService();
				var es = await sv.GetSessionToken();
				Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
					Debug.WriteLine("response from Kahrds");
					Debug.WriteLine(es);
//					var sessionObject = JsonConvert.DeserializeObject<Session>(es);
//					Debug.WriteLine(sessionObject);

				});
			};

			var b = new Button { Text = "List MySets from Web" };
			b.Clicked += async (sender, e) => {
				var sv = new KahrdsWebService();
				var es = await sv.GetMyList();
				Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
					Debug.WriteLine("response from Kahrds");
					Debug.WriteLine(es);
				});
			};

			var c = new Button { Text = "Get one set from Web" };
			c.Clicked += async (sender, e) => {
				var setId = "5535ca1b1c006ab99f000006";
				var sv = new KahrdsWebService();
				var es = await sv.GetOneSetofKahrds(setId);
				Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
					Debug.WriteLine("response from Kahrds");
					Debug.WriteLine(es);
				});
			};


		
			/////Upload NEW SET
			var d = new Button { Text = "Upload sample set to Web" };
			d.Clicked += async (sender, e) => {
				var sv = new KahrdsWebService();
				var es = await sv.UploadNewSet();
				Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
					Debug.WriteLine("response from Kahrds");
					Debug.WriteLine(es);
				});
			};



			///Upload over EXISTING SET




			var z = new Button { Text = "Get kahrdsCommunity" };
			z.Clicked += async (sender, e) => {
				var sv = new KahrdsWebService();
				var es = await sv.GetKahrdCommunity();
				Xamarin.Forms.Device.BeginInvokeOnMainThread( () => {
					Debug.WriteLine("response from Kahrds");
					Debug.WriteLine(es);
				});
			};









			lv = new ListView ();
//			lv.ItemTemplate = new DataTemplate(typeof(TextCell));
//			lv.ItemTemplate.SetBinding(TextCell.TextProperty, "Summary");
//			lv.ItemSelected += (sender, e) => {
//				var eq = (Earthquake)e.SelectedItem;
//				DisplayAlert("Earthquake info", eq.ToString(), "OK", null);
//			};

			Content = new StackLayout {
				Padding = new Thickness (0, 20, 0, 0),
				Children = {
					l,
					a,
					b,
					c,
					z,
					lv
				}
			};
		}
	}
}

