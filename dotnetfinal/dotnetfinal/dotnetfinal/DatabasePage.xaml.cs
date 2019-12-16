using System;
using System.Collections.Generic;
using dotnetfinal.Models;
using Xamarin.Forms;

namespace dotnetfinal
{
    public partial class DatabasePage : ContentPage
    {
        public DatabasePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetUserActivitiesAsync();
        }

        async void OnUserActivityAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatabaseEntryPage
            {
                BindingContext = new UserActivity()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new DatabaseEntryPage
                {
                    BindingContext = e.SelectedItem as UserActivity
                });
            }
        }
    }
}
