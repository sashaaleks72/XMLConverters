using System.Xml.Serialization;

namespace XML.Models
{
    public class Teapot
    {
        [XmlAttribute]
        public int Id { get; set; }

        public string? Title { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string? ImgUrl { get; set; }

        public string? Description { get; set; }

        public string? ManufacturerCountry { get; set; }

        public double Capacity { get; set; }

        public int WarrantyInMonths { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"Title: {Title}\n" +
                $"Quantity: {Quantity}\n" +
                $"Price: {Price}\n" +
                $"ImgUrl: {ImgUrl}\n" +
                $"Description: {Description}\n" +
                $"ManufacturerCountry: {ManufacturerCountry}\n" +
                $"Capacity: {Capacity}\n" +
                $"WarrantyInMonths: {WarrantyInMonths}\n";
        }
    }
}
