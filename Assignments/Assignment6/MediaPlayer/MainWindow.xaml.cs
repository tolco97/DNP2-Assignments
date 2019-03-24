using System;
using System.Windows;
using Microsoft.Win32;

namespace DNP2.Assignments.MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            MediaPlayer.Source = new Uri(openFileDialog.FileName);
            MediaPlayer.Play();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Pause();
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Stop();
        }

        private void MediaPlayer_OnMediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Media loading unsuccessful. " + e.ErrorException.Message);
        }
    }
}
