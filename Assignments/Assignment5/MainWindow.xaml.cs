using System.Windows;

namespace DNP2.Assignment5.MultimediaWPF
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            new DialogWindow().ShowDialog();
        }
        
    }
}
