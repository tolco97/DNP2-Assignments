using System.Collections.ObjectModel;

namespace DNP2.Assignment5.MultimediaWPF.Model
{
    public class MultimediaList
    {
        public static ObservableCollection<Multimedia> Multimedias { get; } = new ObservableCollection<Multimedia>
        {
            new Multimedia
            {
                Title = "1",
                Genre = "1",
                Type = MediaType.CD,
                Artist = "1"
            },
            new Multimedia
            {
                Title = "2",
                Genre = "2",
                Type = MediaType.DVD,
                Artist = "2"
            },
            new Multimedia
            {
                Title = "3",
                Genre = "3",
                Type = MediaType.CD,
                Artist = "3"
            }
        };
    }
}