using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class SetCell : ViewCell
	{
		public SetCell ()
		{
			var label = new Label {
				YAlign = TextAlignment.Center,
				FontSize = 20
			};
			label.SetBinding (Label.TextProperty, "Set");

			var play = new Image {
				Source = ImageSource.FromFile("play.png"),
				HorizontalOptions = LayoutOptions.EndAndExpand
			};

			var edit = new Image {
				Source = ImageSource.FromFile("edit.png"),
				HorizontalOptions = LayoutOptions.End
			};

			var delete = new Image {
				Source = ImageSource.FromFile("delete.png"),
				HorizontalOptions = LayoutOptions.End
			};


			var layout = new StackLayout {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {label, play, edit, delete}
			};
			View = layout;
		}

		protected override void OnBindingContextChanged ()
		{
			// Fixme : this is happening because the View.Parent is getting 
			// set after the Cell gets the binding context set on it. Then it is inheriting
			// the parents binding context.
			View.BindingContext = BindingContext;
			base.OnBindingContextChanged ();
		}
	}
}

