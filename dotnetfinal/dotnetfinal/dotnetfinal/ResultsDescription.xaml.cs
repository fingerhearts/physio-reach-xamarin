using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace dotnetfinal
{
    public partial class ResultsDescription : ContentPage
    {
        public ResultsDescription()
        {
            InitializeComponent();

            Title = "Result Description";

            NavigationPage.SetHasBackButton(this, false);

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#FEFEFE");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#333333");
        }

        public async void Button_Home(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
