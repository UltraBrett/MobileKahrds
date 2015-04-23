using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MobileKahrds 
{
	public class LoginPage : ContentPage
	{
		protected override void OnAppearing ()
		{
			Title = "Login Page";
			var account = (LoginInfo)BindingContext;
			var username = account.Username;

			var questionLabel = new Label { Text = "Username" };
			var questionEntry = new Entry ();
			questionEntry.SetBinding (Entry.TextProperty, "Username");

			var answerLabel = new Label { Text = "Password" };
			var answerEntry = new Entry ();
			answerEntry.SetBinding (Entry.TextProperty, "Password");

			var saveButton = new Button { Text = "Save Credentials" };
			saveButton.Clicked += async (sender, e) => {
				var info = (LoginInfo)BindingContext;

				int usernameFlag = (info.Username.Length > 0) ? 0 : 1;
				int passwordFlag = (info.Password.Length > 0) ? 0 : 1;

				for(int i = 0; i < info.Username.Length; i++){
					if(info.Username[i] == ' ' && usernameFlag != 2)
						usernameFlag = 1;
					if(info.Username[i] != ' ')
						usernameFlag = 2;
				}

				for(int i = 0; i < info.Password.Length; i++){
					if(info.Password[i] == ' ' && passwordFlag != 2)
						passwordFlag = 1;
					if(info.Password[i] != ' ')
						passwordFlag = 2;
				}

				if(usernameFlag == 1 || passwordFlag == 1){
					await DisplayAlert("You goofed!", "None of the fields can be empty.", "Ok");
				} else {
					var sv = new KahrdsWebService();
					var es = await sv.AccountTest(info.Username, info.Password);
					if(!es.Contains("WRONG_PASSWORD")){
						if(username == null){
							App.Database.NewAccount(info);
						} else {
							App.Database.UpdateAccount(info, username);
						}
						await Navigation.PopAsync();
					} else {
						await DisplayAlert("You goofed!", "Username/Password combination invalid.", "Ok");
					}
				}
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) => {
				Navigation.PopAsync();
			};

			Content = new StackLayout {
				Padding = new Thickness(20),
				Children = {
					questionLabel, questionEntry,
					answerLabel, answerEntry,
					saveButton,
					cancelButton
				}
			};
		}
	}
}

