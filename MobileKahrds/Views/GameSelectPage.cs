using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class GameSelectPage : CarouselPage
	{
		public GameSelectPage ()
		{
			this.Title = "Games";

			this.ItemsSource = new Game[] 
			{
				new Game("Hangman", "defeatV2.jpg"),
				new Game("Flash Kahrds", "flashkahrds.jpg"),
				new Game("Kahrd Quiz", "idklol.jpg")
			};

			this.ItemTemplate = new DataTemplate(() =>
			{
				return new GamePage();
			});
		}
	}
}

