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
        readonly System.Timers.Timer _timer = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            // Show current date/time before drawing the screen
            UpdateTimeDisplay();

            _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            _timer.Enabled = true;
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(UpdateTimeDisplay));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void UpdateTimeDisplay()
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                DigialTime.Content = $"{DateTime.Now:HH:mm}";
                DigitalDate.Content = $"{DateTime.Now:D}";
            }));
        }
    }
}
