using XML.Models;
using XML.Services;

namespace XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //XmlTransform.TransformXML(@"XMLFiles\teapots-data.xml", @"XMLFiles\teapots-styles.xslt", @"XMLFiles\teapots-view.html");

            //var xmlDom = new XmlDom(@"XMLFiles\teapots-data.xml", @"XMLSchemas\teapots.xsd");
            var teapots = new List<Teapot>
            {
                new Teapot
                {
                    Id = 1,
                    Capacity = 1.6,
                    Description = "Good teapot",
                    ImgUrl = "url",
                    ManufacturerCountry = "Germany",
                    Price = 1199,
                    Quantity = 12,
                    Title = "Teapot model 1",
                    WarrantyInMonths = 12
                },
                new Teapot
                {
                    Id = 2,
                    Capacity = 1.6,
                    Description = "Good teapot",
                    ImgUrl = "url",
                    ManufacturerCountry = "Germany",
                    Price = 1699,
                    Quantity = 10,
                    Title = "Teapot model 2",
                    WarrantyInMonths = 12
                }
            };

            XmlJAXB.Serialize(@"XMLFiles\teapots-data.xml", teapots);
            teapots = XmlJAXB.Deserialize(@"XMLFiles\teapots-data.xml");
            //Console.WriteLine();

            foreach (var teapot in teapots!)
            {
                Console.WriteLine(teapot);
            }


            //var xmlDom = new XmlDom(@"XMLFiles\teapots-data.xml", @"XMLSchemas\teapots.xsd");
            //xmlDom.Serialize(teapots);
        }
    }
}