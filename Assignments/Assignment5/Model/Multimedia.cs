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
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Artist
        {
            get => _artist;
            set
            {
                _artist = value;
                OnPropertyChanged(nameof(Artist));
            }
        }

        public string Genre
        {
            get => _genre;
            set
            {
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        public MediaType Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"Title: {Title} | Artist: {Artist} | Genre: {Genre} | MediaType: {Type}";
        }
    }
}