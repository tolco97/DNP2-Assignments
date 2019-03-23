using System;
using System.Windows;

namespace DNP2.Assignment5.MultimediaWPF
{
    /// <summary>
    /// Interaction logic for AddNewItemWindow.xaml
    /// </summary>
    public partial class AddNewItemWindow : Window
    {
        public AddNewItemWindow()
        {
            InitializeComponent();
            PopulateMediaTypesComboBox();
        }

        public Multimedia CreatedMultimedia { get; set; }

        /// <summary>
        /// Populate the combo box with all values of the MediaType enum
        /// </summary>
        private void PopulateMediaTypesComboBox()
        {
            // Get all types of the Media Type enum
            string[] mediaTypes = Enum.GetNames(typeof(MediaType));

            // Add all values to combo box
            foreach (string mediaType in mediaTypes)
            {
                MediaTypeComboBox.Items.Add(mediaType);
            }

            // Point first item
            if (MediaTypeComboBox.Items.Count > 0)
            {
                MediaTypeComboBox.SelectedIndex = 0;
            }
        }

        private void AddNewMultimediaOnClick(object sender, RoutedEventArgs e)
        {
            // Get all values
            string title = TitleTextBox.Text;
            string artist = ArtistTextBox.Text;
            string genre = GenreTextBox.Text;
            var mediaType = (MediaType) Enum.Parse(typeof(MediaType), MediaTypeComboBox.SelectionBoxItem.ToString());

            // A missing text field - fail
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(artist) || string.IsNullOrWhiteSpace(genre))
            {
                // Show error message when invalid input
                MessageBox.Show("Invalid input. Please revise the multimedia data.", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create multimedia object
            CreatedMultimedia = new Multimedia
            {
                Title = title,
                Artist = artist,
                Genre = genre,
                Type = mediaType
            };

            // Success
            DialogResult = true;
        }

        private void CancelOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
