﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dotnetfinal.Exercises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exercise3 : ContentPage
    {
        public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();

        public Exercise3()
        {
            InitializeComponent();
        }

        public void Countdown(bool running)
        {
            int _SecondsElapsed = 8;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                while (_SecondsElapsed >= 0)
                {
                    switch (_SecondsElapsed)
                    {
                        case 8:
                            countdownTimer.Text = "Ready";
                            break;
                        case 7:
                            countdownTimer.Text = "Set";
                            break;
                        case 6:
                            countdownTimer.Text = "Go!";
                            break;
                        default:
                            countdownTimer.Text = _SecondsElapsed.ToString();
                            break;
                    }
                    _SecondsElapsed--;
                    return true;
                }
                return false;
            });
        }


        void StartButton(object sender, EventArgs e)
        {
            Countdown(true);
            //Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            //Accelerometer.Start(SensorSpeed.UI);
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
            var vData = new OxyData(Coordinates);
            //Button button = sender as Button;
            await Navigation.PushAsync(new Results(Coordinates) { Title = "Results", BindingContext = vData });
        }
    }
}