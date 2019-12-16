using System;
using System.Collections.Generic;
using dotnetfinal.Models;
using Xamarin.Forms;

namespace dotnetfinal
{
    public partial class DatabaseEntryPage : ContentPage
    {
        public DatabaseEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            UserActivity userActivity = new UserActivity();
            userActivity.ActivityID = Convert.ToInt32(ActivityID.Text);
            userActivity.MaxXMotion = Convert.ToDecimal(MaxXMotion.Text);
            userActivity.MaxYMotion = Convert.ToDecimal(MaxYMotion.Text);
            userActivity.MaxZMotion = Convert.ToDecimal(MaxZMotion.Text);
            userActivity.IsCompleted = false;
            userActivity.Date = DateTime.UtcNow;

            await App.Database.SaveUserActivityAsync(userActivity);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (UserActivity)BindingContext;
            await App.Database.DeleteUserActivityAsync(note);
            await Navigation.PopAsync();
        }
    }
}
