using SharpLab3.Models;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SharpLab3.Controllers
{
    public class LibraryManager
    {
        private readonly string _libPath = "PageData\\albums.xml";
        public List<Album> Albums { get; } = new List<Album>();

        static void ValidationCallback(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write("WARNING: ");
            else if (args.Severity == XmlSeverityType.Error)
                Console.Write("ERROR: ");

            Console.WriteLine(args.Message);
        }

        public LibraryManager(string root)
        {
            var rawXml = File.ReadAllText(root + _libPath);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(rawXml);

            xmlDoc.Schemas.Add(new XmlSchema());

            XmlNodeList nodes = xmlDoc.GetElementsByTagName("album");
            for (int i = 0; i < nodes.Count; i++)
            {
                Album album = new Album();

                foreach (XmlElement el in nodes[i].ChildNodes)
                {
                    switch (el.Name)
                    {
                        case "id":
                            album.Id = Convert.ToUInt32(el.InnerText);
                            break;
                        case "name":
                            album.Name = el.InnerText;
                            break;
                        case "artist":
                            album.Artist = el.InnerText;
                            break;
                        case "genres":
                            List<string> genres = new List<string>();
                            foreach (XmlElement e in el.ChildNodes)
                                if (e.Name == "genre")
                                    genres.Add(e.InnerText);
                            album.Genres = genres;
                            break;
                        case "releaseYear":
                            album.ReleaseYear = Convert.ToUInt16(el.InnerText);
                            break;
                        case "albumCover":
                            album.AlbumCover = el.InnerText;
                            break;
                        case "description":
                            album.Description = el.InnerText;
                            break;
                    }
                }
                Albums.Add(album);
            }
        }
    }
}
