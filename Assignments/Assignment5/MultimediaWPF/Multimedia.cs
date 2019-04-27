using System.ComponentModel;
using System.Runtime.CompilerServices;
using DNP2.Assignment5.MultimediaWPF.Properties;

namespace DNP2.Assignment5.MultimediaWPF
{
    public class Multimedia : INotifyPropertyChanged
    {
        public string Artist
        {
            get => Artist;
            set { Artist = value; OnPropertyChanged(nameof(Artist)); }
        }

        public string Genre
        {
            get => Genre;
            set { Genre = value; OnPropertyChanged(nameof(Genre)); }
        }

        public string Title
        {
            get => Title;
            set { Title = value; OnPropertyChanged(nameof(Title)); }
        }

        public MediaType Type
        {
            get => Type;
            set { Type = value; OnPropertyChanged(nameof(Type));}
        }

        public override string ToString()
        {
            return $"Artist: {Artist} - Genre: {Genre} - Title: {Title} - MediaType: {Type.ToString()}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
