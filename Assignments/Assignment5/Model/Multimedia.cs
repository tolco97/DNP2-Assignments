using System.ComponentModel;

namespace DNP2.Assignment5.MultimediaWPF.Model
{
    public class Multimedia : INotifyPropertyChanged
    {
        private string _artist;
        private string _genre;
        private string _title;
        private MediaType _type;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyRaised(nameof(Title));
            }
        }

        public string Artist
        {
            get => _artist;
            set
            {
                _artist = value;
                OnPropertyRaised(nameof(Artist));
            }
        }

        public string Genre
        {
            get => _genre;
            set
            {
                _genre = value;
                OnPropertyRaised(nameof(_genre));
            }
        }

        public MediaType Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyRaised(nameof(Type));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"Title: {Title} | Artist: {Artist} | Genre: {Genre} | MediaType: {Type}";
        }
    }
}