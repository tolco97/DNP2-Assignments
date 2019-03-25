using System.Windows;
using System.Windows.Controls;

namespace DNP2.Assignment5.MultimediaWPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddMultimediaOnClick(object sender, RoutedEventArgs e)
        {
            var addNewItemWindow = new AddNewItemWindow();

            bool? closed = addNewItemWindow.ShowDialog();

            if (closed.HasValue && closed.Value)
            {
                // Get created object
                Multimedia newMultimedia = addNewItemWindow.NewMultimedia;
                
                // Create new list box item
                var newMultimediaListBoxItem = new ListBoxItem
                {
                    Content = newMultimedia.ToString()
                };
                
                // Click event for multimedia button
                newMultimediaListBoxItem.Selected += (o, args) =>
                {
                    SelectedMultimediaTextBox.Text = newMultimedia.ToString();
                };
                MultimediaListBox.Items.Add(newMultimediaListBoxItem);
            }
        }
    }
}