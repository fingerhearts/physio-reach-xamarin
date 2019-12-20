using dotnetfinal.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;
using Xamarin.Forms;

namespace dotnetfinal
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Title = "Exercises";

            //NavigationPage.SetHasBackButton(this, false);
            //NavigationPage page = Application.Current.MainPage as NavigationPage;
            //page.BarBackgroundColor = Color.FromHex("#333333");
            

            //            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#333333");
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }

        private async void Authenticator_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            await Navigation.PushAsync(new Exercises.Exercise1());
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Exercises.ExercisesPage());
        }

        async void GoogleLogin(object sender, EventArgs e)
        {
            var authenticator = new OAuth2Authenticator(
                Secrets.GoogleAuthKey,
                null,
                Secrets.GoogleScope,
                new Uri("https://accounts.google.com/o/oauth2/auth"),
                new Uri(Secrets.GoogleRedirectUrl),
                new Uri("https://www.googleapis.com/oauth2/v4/token"),
                null,
                true);
            authenticator.Completed += Authenticator_Completed;
            var presenter = new OAuthLoginPresenter();
            presenter.Login(authenticator);
            await Navigation.PushAsync(new Exercises.Exercise1());
        }
    }
}
