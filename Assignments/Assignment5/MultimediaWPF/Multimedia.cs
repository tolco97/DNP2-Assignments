using System.ComponentModel;
using System.Runtime.CompilerServices;
using DNP2.Assignment5.MultimediaWPF.Properties;

namespace DNP2.Assignment5.MultimediaWPF
{
    public class Multimedia : INotifyPropertyChanged
    {
        public string Artist { get; set; }

        public string Genre { get; set; }

        public string Title { get; set; }

        public MediaType Type { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
