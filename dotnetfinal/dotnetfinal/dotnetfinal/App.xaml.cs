using System;
using System.IO;
using dotnetfinal.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dotnetfinal
{
    public partial class App : Application
    {
        static PhysioReachDatabase database;

        public static PhysioReachDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PhysioReachDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dotnetfinal.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
