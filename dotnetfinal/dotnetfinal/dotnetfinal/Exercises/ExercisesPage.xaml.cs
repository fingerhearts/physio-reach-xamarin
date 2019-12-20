using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dotnetfinal.Exercises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisesPage : ContentPage
    {
        public ExercisesPage()
        {
            InitializeComponent();

            Title = "Exercises";

            NavigationPage.SetHasBackButton(this, false);

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#3BC368");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }

        async void ButtonClicked1(object sender, EventArgs e)
        {
            //Button button = sender as Button;
            await Navigation.PushAsync(new Exercises.Exercise1());
        }
        async void ButtonClicked2(object sender, EventArgs e)
        {
            //Button button = sender as Button;
            await Navigation.PushAsync(new Exercises.Exercise2());
        }
        async void ButtonClicked3(object sender, EventArgs e)
        {
            //Button button = sender as Button;
            await Navigation.PushAsync(new Exercises.Exercise3());
        }
    }
}