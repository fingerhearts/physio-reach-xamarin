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
    public partial class Exercise1 : ContentPage
    {
        public List<Coordinate> Coordinates { get; set; } = new List<Coordinate>();

        public Exercise1()
        {
            InitializeComponent();

            Title = "Shoulder Abduction";

            NavigationPage.SetHasBackButton(this, false);

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#FEFFFF");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#333333");

            // Utilize SimpleAudioPlayer Plugin intergface to bring in method CreateSimpleAudioPlayer()
            // Then the SimpleAudioPlayer uses Load method to bring in the audio file
            var audio = CrossSimpleAudioPlayer.Current;
            audio.Load(GetStreamFromFile("Envision.mp3"));
        }

        /// <summary>
        /// The method loads the specified manifest resource from this assembly then finds the audio file from the folder
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("dotnetfinal." + filename);
            return stream;
        }

        /// <summary>
        /// Once the start button is clicked, bring in the audio object and start the timer
        /// Change the start button text to Running when the timer is running
        /// Count down 8 seconds including prep time
        /// While counting down to 5th second, start the accelerometer
        /// Once counts down to 0, stop the accelerometer and stop the audio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Countdown(object sender, EventArgs e)
        {
            var stream = GetStreamFromFile("countdown.mp3");
            var audio = CrossSimpleAudioPlayer.Current;
            audio.Load(stream);

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
                audio.Play();
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
                //start.Text = "Start";
                countdownTimer.Text = "";
                audio.Stop();
                var vData = new OxyData(Coordinates);
                //Button button = sender as Button;
                Navigation.PushAsync(new Results(Coordinates) { Title = "Results", BindingContext = vData });
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
    }
}