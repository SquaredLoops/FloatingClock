using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace FloatingClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int welcomeIntroCounter = 3;
        readonly System.Timers.Timer _timer = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            // Call this event on every "tick"
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            _timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(UpdateTimeDisplay));
            UpdateTimeDisplay();
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void UpdateTimeDisplay()
        {
            // Show welcome message for a few ticks
            if (welcomeIntroCounter-- > 0) { return; }
            welcomeIntroCounter = 0;

            // Update the date and time
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                DigialTime.Content = $"{DateTime.Now:HH:mm}";
                DigitalDate.Content = $"{DateTime.Now:dddd}, {DateTime.Now:D}";
            }));
        }
    }
}
