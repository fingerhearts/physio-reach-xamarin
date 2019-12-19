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
        }

        public async void Button_Home(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
