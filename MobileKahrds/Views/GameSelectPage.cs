using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace MobileKahrds
{
	public class GameSelectPage : CarouselPage
	{
		public GameSelectPage ()
		{
			this.Title = "CarouselPage";

			this.ItemsSource = new Game[] 
			{
				new Game("Hangman", Color.Red),
				new Game("Flash Cards", Color.Yellow),
				new Game("?????", Color.Green)
			};

			this.ItemTemplate = new DataTemplate(() =>
				{
					return new GamePage(true);
				});
		}
	}
}

