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
                Multimedia newMultimedia = addNewItemWindow.CreatedMultimedia;

                // Create new list box item
                var newMultimediaItem = new ListBoxItem
                {
                    Content = $"Artist: {newMultimedia.Artist} - Genre: {newMultimedia.Genre} - Title: {newMultimedia.Title} -MediaType: {newMultimedia.Type.ToString()}"
                };
                
                // Click event for multimedia button
                newMultimediaItem.Selected += (o, args) =>
                {
                    SelectedMultimediaTextBox.Text = newMultimediaItem.Content.ToString();
                };
                MultimediaListBox.Items.Add(newMultimediaItem);
            }
            else
            {
                // Show error message when invalid input
                MessageBox.Show("Invalid input.", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}