using dotnetfinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dotnetfinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Results : ContentPage
    {
        public List<Coordinate> Coordinates { get; set; }
        public Results(List<Coordinate> coordinates)
        {
            Coordinates = coordinates;
            InitializeComponent();

            Title = "Result";

            NavigationPage.SetHasBackButton(this, false);

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#333333");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Coordinate max = Coordinates[0];
            Coordinate min = Coordinates[0];

            foreach (Coordinate coord in Coordinates)
            {
                if (coord.YValue > max.YValue)
                {
                    max = coord;
                }
                if (coord.YValue < min.YValue)
                {
                    min = coord;
                }
            }

            double totalHeight = max.YValue - min.YValue;

            MaxHeight.Text = "Your Maximum height was: " + totalHeight.ToString() + " physios";

            UserActivity activity = new UserActivity()
            {
                IsCompleted = true,
                Date = DateTime.Now,
                MaxYMotion = (decimal)totalHeight,
                ActivityID = 1
            };

            App.Database.SaveUserActivityAsync(activity);
        }

        public async void ButtonDescription(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResultsDescription());
        }
    }
}