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
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            string test = Coordinates[0].XValue.ToString();

            TestDisplay.Text = test;
        }
    }
}