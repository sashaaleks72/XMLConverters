using System.Xml.Serialization;
using XML.Models;

namespace XML.Services
{
    public static class XmlJAXB
    {
        public static void Serialize(string docPath, List<Teapot> teapots)
        {
            var serializer = new XmlSerializer(typeof(List<Teapot>));

            using (var writer = new StreamWriter(docPath))
            {
                serializer.Serialize(writer, teapots);
                writer.Flush();
            }
        }

        public static List<Teapot> Deserialize(string docPath)
        {
            var teapots = new List<Teapot>();

            var serializer = new XmlSerializer(typeof(List<Teapot>));

            using (var reader = new StreamReader(docPath))
            {
                teapots = serializer.Deserialize(reader) as List<Teapot>;
            }

            return teapots!;
        }
    }
}
