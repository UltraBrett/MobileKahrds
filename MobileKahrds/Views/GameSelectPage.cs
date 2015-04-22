using Xamarin.Forms;

namespace MobileKahrds
{
	public class GameSelectPage : CarouselPage
	{		
		public GameSelectPage (string setName)
		{
			Title = "Games";

			ItemsSource = new [] 
			{
				new Game("Hangman", "defeatV2.jpg", setName),
				new Game("Flash Kahrds", "flashkahrds.jpg", setName),
				new Game("Kahrd Quiz", "idklol.jpg", setName)
			};

			ItemTemplate = new DataTemplate(() =>
			{
				return new GamePage();
			});
		}
	}
}

