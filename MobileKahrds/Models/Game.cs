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
			this.Source = imageSource;
		}

		public string Name { private set; get; }

		public string Source { private set; get; }

		public override string ToString()
		{
			return Name;
		}
	}

}
