using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using dotnetfinal.Models;

namespace dotnetfinal.Exercises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exercise1 : ContentPage
    {
        public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();

        public Exercise1()
        {
            InitializeComponent();
        }
        void StartButton(object sender, EventArgs e)
        {
            if (Accelerometer.IsMonitoring)
            {
                return;
            }
            LabelX.Text = "Running";
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Start(SensorSpeed.UI);
        }
        void StopButton(object sender, EventArgs e)
        {
            if (!Accelerometer.IsMonitoring)
            {
                return;
            }
            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
            Accelerometer.Stop();
            LabelX.Text = "Stopped";
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            Coordinate coordinate = new Coordinate();
            
            coordinate.XValue = Math.Round(Convert.ToDouble(e.Reading.Acceleration.X) * 100 / 2.54, 2);
            coordinate.YValue = Math.Round(Convert.ToDouble(e.Reading.Acceleration.Y) * 100 / 2.54, 2);
            coordinate.ZValue = Math.Round(Convert.ToDouble(e.Reading.Acceleration.Z) * 100 / 2.54, 2);

            Coordinates.Add(coordinate);
        }
        async void ResultsClicked(object sender, EventArgs e)
        {
            //Button button = sender as Button;
            await Navigation.PushAsync(new Results(Coordinates));
        }
    }
}