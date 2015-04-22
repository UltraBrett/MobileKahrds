using Xamarin.Forms;

namespace MobileKahrds
{
	class GamePage : ContentPage
	{
		protected override void OnAppearing ()
		{
			Game game = (Game)BindingContext;

			ToolbarItem tbi = new ToolbarItem ("play2", "play2", () => {
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
			}, 0, 0);
			ToolbarItems.Add (tbi);

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
					image
				}
			};
		}
	}
}
