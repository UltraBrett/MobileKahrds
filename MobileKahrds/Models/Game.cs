using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	// Used in TabbedPageDemoPage & CarouselPageDemoPage.
	class Game
	{
		public Game(string name, string imageSource)
		{
			this.Name = name;
			this.Image = imageSource;
		}

		public string Name { private set; get; }

		public string Image { private set; get; }

		public override string ToString()
		{
			return Name;
		}
	}

}
