﻿using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class SetCell : ViewCell
	{
		SetItem setItem;
		public SetCell ()
		{
			var label = new Label {
				YAlign = TextAlignment.Center,
				FontSize = 20
			};
			label.SetBinding (Label.TextProperty, "Set");

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

