using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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

            var audio = CrossSimpleAudioPlayer.Current;
            audio.Load(GetStreamFromFile("Envision.mp3"));
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("dotnetfinal." + filename);
            return stream;
        }

        public void Countdown(object sender, EventArgs e)
        {
            var stream = GetStreamFromFile("Envision.mp3");
            var audio = CrossSimpleAudioPlayer.Current;
            audio.Load(stream);

            int _SecondsElapsed = 8;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                start.Text = "Running";
                LabelX.Text = "";
                audio.Play();
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
                            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
                            Accelerometer.Start(SensorSpeed.UI);
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
                audio.Stop();
                return false;
            });
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