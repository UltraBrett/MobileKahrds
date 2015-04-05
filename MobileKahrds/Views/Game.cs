using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	// Used in TabbedPageDemoPage & CarouselPageDemoPage.
	class Game
	{
		public Game(string name, Color color)
		{
			this.Name = name;
			this.Color = color;
		}

		public string Name { private set; get; }

		public Color Color { private set; get; }

		public override string ToString()
		{
			return Name;
		}
	}

}
