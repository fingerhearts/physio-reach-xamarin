using Android.Media;
using Android.OS;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dotnetfinal.Exercises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exercise1 : ContentPage
    {
        public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();

        ISimpleAudioPlayer player;

        public Exercise1()
        {
            InitializeComponent();
        }

        public void Countdown()
        {
            int _SecondsElapsed = 8;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                start.Text = "Running";
                LabelX.Text = "";
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
                Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                Accelerometer.Stop();
                LabelX.Text = "Stopped";
                start.Text = "Start";
                countdownTimer.Text = "";
            return false;
            });
        }

        void StartButton(object sender, EventArgs e)
        {
            Countdown();
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Start(SensorSpeed.UI);
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