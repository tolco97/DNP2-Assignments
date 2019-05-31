using System;
using System.Windows;
using System.IO;
using System.Windows.Threading;
using Microsoft.Win32;

namespace DNP2.Assignments.MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            _timer.Tick += OnTimerTick;
            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (MediaViewer.Source != null && MediaViewer.NaturalDuration.HasTimeSpan)
            {
                ProgressBar.Minimum = 0;
                ProgressBar.Maximum = MediaViewer.NaturalDuration.TimeSpan.TotalSeconds;
                ProgressBar.Value = MediaViewer.Position.TotalSeconds;
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            // Initialize Media element with media file
            var openFileDialog = new OpenFileDialog();
            bool? success = openFileDialog.ShowDialog();

            if (success.HasValue && success.Value)
            {
                MediaViewer.Source = new Uri(openFileDialog.FileName);

                // Update progress label
                FilePlayingLabel.Content = $"Playing: {Path.GetFileName(openFileDialog.FileName)}";

                // Update progress bar
                ProgressBar.Value = 0;
                ProgressBar.Minimum = 0;
                ProgressBar.Maximum = MediaViewer.Position.TotalSeconds;
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MediaViewer.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            MediaViewer.Pause();
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            MediaViewer.Stop();
        }

        private void MediaPlayer_OnMediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show($"Media loading unsuccessful. {e.ErrorException.Message}");
        }

        private void ProgressBar_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ProgressLabel.Content = TimeSpan.FromSeconds(ProgressBar.Value).ToString(@"hh\:mm\:ss");
        }
    }
}
