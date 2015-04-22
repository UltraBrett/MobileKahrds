using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	// Used in TabbedPageDemoPage & CarouselPageDemoPage.
	class Game
	{
		public Game(string name, string imageSource, string setName)
		{
			this.Name = name;
			this.Source = imageSource;
			this.Set = setName;
		}

		public string Name { private set; get; }

		public string Source { private set; get; }

		public string Set { private set; get; } 

		public override string ToString()
		{
			return Name;
		}
	}

}
