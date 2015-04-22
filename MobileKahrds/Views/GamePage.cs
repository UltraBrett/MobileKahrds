using Xamarin.Forms;

namespace MobileKahrds
{
	class GamePage : ContentPage
	{
		protected override void OnAppearing ()
		{
			Game game = (Game)BindingContext;

			var playButton = new Button { 
				Text = "Play!",
				VerticalOptions = LayoutOptions.Center
			};

			//Play! button for each game page is set here
			playButton.Clicked += (sender, e) => {
				switch(game.Name){
				case "Hangman":
					var hangman = new HangmanPage();
					hangman.BindingContext = game;
					Navigation.PushAsync(hangman);
					break;
				case "Kahrd Quiz":
					var quiz = new QuizPage();
					quiz.BindingContext = game;
					Navigation.PushAsync(quiz);
					break;
				case "Flash Kahrds":
					var flash = new FlashCards();
					flash.BindingContext = game;
					Navigation.PushAsync(flash);
					break;
				};

			};

			Image image = new Image
			{
				Source = ImageSource.FromFile(game.Source),
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Label bigLabel = new Label
			{
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center
			};
			bigLabel.SetBinding(Label.TextProperty, "Name");

			// Build the page
			Content = new StackLayout
			{
				Children = 
				{
					bigLabel,
					image,
					playButton
				}
			};
		}
	}
}
