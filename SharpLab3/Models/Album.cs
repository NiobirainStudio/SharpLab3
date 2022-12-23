namespace SharpLab3.Models
{
    public class Album
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public List<string> Genres { get; set; }
        public ushort ReleaseYear { get; set; }
        public string AlbumCover { get; set; }
        public string Description { get; set; }
    }
}
