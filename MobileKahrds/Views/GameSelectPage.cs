using System;
using Xamarin.Forms;
using System.Collections.Generic;

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
				new Game("Flash Cards", "defeatV2.jpg"),
				new Game("?????", "defeatV2.jpg")
			};

			this.ItemTemplate = new DataTemplate(() =>
				{
					return new GamePage(true);
				});
		}
	}
}

