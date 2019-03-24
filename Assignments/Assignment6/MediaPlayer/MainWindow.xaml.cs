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
            MediaViewer.Source = new Uri(openFileDialog.FileName);
            MediaViewer.Play();
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
            MessageBox.Show("Media loading unsuccessful. " + e.ErrorException.Message);
        }
    }
}
