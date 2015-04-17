﻿using Xamarin.Forms;

namespace MobileKahrds
{
	public class SetPage : ContentPage
	{
		ListView listView;
		SetItem setItem;

		public SetPage ()
		{
			this.SetBinding(ContentPage.TitleProperty, "Set");

			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate 
				(typeof (ItemCell));
			listView.ItemSelected += (sender, e) => {
				var item = (SetItem)e.SelectedItem;
				var page = new SetPage();
				page.BindingContext = item;
				Navigation.PushAsync(page);
			};

			var layout = new StackLayout();
			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

			ToolbarItem tbi = new ToolbarItem ("+", "plus", () => {
				var todoItem = new SetItem();
				var todoPage = new CreateSetPage();
				todoPage.BindingContext = todoItem;
				Navigation.PushAsync(todoPage);
			}, 0, 0);
			ToolbarItems.Add (tbi);

			tbi = new ToolbarItem ("delete", "delete", () => {
				App.Database.DeleteSet(setItem.Set);
				Navigation.PopAsync();
			}, 0, 1);
			ToolbarItems.Add (tbi);
		}

		protected override void OnAppearing ()
		{
			setItem = (SetItem)BindingContext;
			base.OnAppearing ();
			listView.ItemsSource = App.Database.GetSetItems(setItem.Set);
		}
	}
}

