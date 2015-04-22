using Xamarin.Forms;

namespace MobileKahrds
{
	public class GameSelectPage : CarouselPage
	{		

		SetItem setItem;
		public GameSelectPage ()
		{
			Title = "Games";

			ItemsSource = new [] 
			{
				new Game("Hangman", "defeatV2.jpg", setItem.Set),
				new Game("Flash Kahrds", "flashkahrds.jpg", setItem.Set),
				new Game("Kahrd Quiz", "idklol.jpg", setItem.Set)
			};

			ItemTemplate = new DataTemplate(() =>
			{
				return new GamePage();
			});
		}

		protected override void OnAppearing ()
		{
			setItem = (SetItem)BindingContext;
		}
	}
}

