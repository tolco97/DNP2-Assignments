﻿using System;
using System.ComponentModel;
using System.Windows;
using DNP2.Assignment5.MultimediaWPF.Model;

namespace DNP2.Assignment5.MultimediaWPF
{
    public partial class AddMultimediaWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private MediaType _mediaType;

        public AddMultimediaWindow()
        {
            InitializeComponent();
            PopulateMediaTypeComboBox();
        }

        public MediaType MediaType
        {
            get => _mediaType;
            set
            {
                _mediaType = value;
                OnPropertyRaised(nameof(MediaType));
            }
        }
        private void OnPropertyRaised(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnAddMultimediaClick(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text, artist = ArtistTextBox.Text, genre = GenreTextBox.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(artist) || string.IsNullOrWhiteSpace(genre))
            {
                MessageBox.Show("Invalid input.", "Multimedia", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var multimedia = new Multimedia
            {
                Genre = genre,
                Title = title,
                Type = MediaType,
                Artist = artist
            };

            MultimediaList.Multimedias.Add(multimedia);
            
            Close();
        }

        private void PopulateMediaTypeComboBox()
        {
            Array multimediaTypes = Enum.GetValues(typeof(MediaType));
            MediaTypeComboBox.ItemsSource = multimediaTypes;
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}