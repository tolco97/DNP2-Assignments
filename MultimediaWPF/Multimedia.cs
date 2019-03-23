using System.ComponentModel;
using System.Runtime.CompilerServices;
using DNP2.Assignment5.MultimediaWPF.Properties;

namespace DNP2.Assignment5.MultimediaWPF
{
    public class Multimedia : INotifyPropertyChanged
    {
        private string _artist;
        private string _genre;
        private string _title;
        private MediaType _type;

        public string Artist
        {
            get => _artist;
            set => _artist = value;
        }

        public string Genre
        {
            get => _genre;
            set => _genre = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public MediaType Type
        {
            get => _type;
            set => _type = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
