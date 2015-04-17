using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class ItemCell : ViewCell
	{
		SetItem setItem;
		public ItemCell ()
		{
			var label = new Label {
				YAlign = TextAlignment.Center,
				FontSize = 20
			};
			label.SetBinding (Label.TextProperty, "Answer");

			var layout = new StackLayout {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {label}
			};
			View = layout;
		}
			
		protected override void OnBindingContextChanged ()
		{
			setItem = (SetItem)BindingContext;
			View.BindingContext = BindingContext;
			base.OnBindingContextChanged ();
		}
	}
}

