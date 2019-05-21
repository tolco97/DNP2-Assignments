namespace DNP2.Assignment5.MultimediaWPF
{
    public class Multimedia/* : INotifyPropertyChanged*/
    {
        public string Artist { get; set; }

        public string Genre { get; set; }

        public string Title { get; set; }

        public MediaType Type { get; set; }

        public override string ToString()
        {
            return $"Artist: {Artist} - Genre: {Genre} - Title: {Title} - MediaType: {Type.ToString()}";
        }

    }
}
