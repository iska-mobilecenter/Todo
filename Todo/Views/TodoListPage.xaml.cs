﻿using Microsoft.Azure.Mobile.Push;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Todo
{
	public partial class TodoListPage : ContentPage
	{
		public TodoListPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Reset the 'resume' id, since we just want to re-start here
			((App)App.Current).ResumeAtTodoId = -1;
			listView.ItemsSource = await App.Database.GetItemsAsync();
		}

        async void OnItemAdded(object sender, EventArgs e)
		{
            Microsoft.Azure.Mobile.Analytics.Analytics.TrackEvent("Add button clicked");
            await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = new TodoItem()
			});
		}

        async void OnItemCrashed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
			Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);

			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = e.SelectedItem as TodoItem
			});
		}
	}
}
