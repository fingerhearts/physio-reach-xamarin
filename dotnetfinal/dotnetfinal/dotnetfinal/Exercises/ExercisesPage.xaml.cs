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