using System.Xml;
using XML.Models;

namespace XML.Services
{
    public class XmlDom
    {
        private XmlDocument _xmlDocument { get; set; }
        private string _docPath { get; set; }
        private string? _schemaPath { get; set; }

        public XmlDom(string docPath)
        {
            _docPath = docPath;
            _xmlDocument = new XmlDocument();
        }

        public XmlDom(string docPath, string schemaPath)
        {
            _docPath = docPath;
            _schemaPath = schemaPath;
            _xmlDocument = new XmlDocument();
        }

        public void Serialize(List<Teapot> teapots)
        {
            var declaration = _xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
            var root = _xmlDocument.CreateElement("teapots");

            foreach (var teapot in teapots)
            {
                var teapotNode = _xmlDocument.CreateElement("teapot");

                var id = _xmlDocument.CreateAttribute("id");
                var title = _xmlDocument.CreateElement("title");
                var quantity = _xmlDocument.CreateElement("quantity");
                var price = _xmlDocument.CreateElement("price");
                var capacity = _xmlDocument.CreateElement("capacity");
                var warrantyInMonths = _xmlDocument.CreateElement("warrantyInMonths");
                var manufacturerCountry = _xmlDocument.CreateElement("manufacturerCountry");
                var description = _xmlDocument.CreateElement("description");
                var imgUrl = _xmlDocument.CreateElement("imgUrl");

                id.Value = teapot.Id.ToString();
                title.InnerText = teapot.Title!;
                quantity.InnerText = teapot.Quantity.ToString();
                price.InnerText = teapot.Price.ToString();
                capacity.InnerText = teapot.Capacity.ToString();
                warrantyInMonths.InnerText = teapot.WarrantyInMonths.ToString();
                manufacturerCountry.InnerText = teapot.ManufacturerCountry!;
                description.InnerText = teapot.Description!;
                imgUrl.InnerText = teapot.ImgUrl!;

                teapotNode.Attributes.Append(id);
                teapotNode.AppendChild(title);
                teapotNode.AppendChild(quantity);
                teapotNode.AppendChild(price);
                teapotNode.AppendChild(capacity);
                teapotNode.AppendChild(warrantyInMonths);
                teapotNode.AppendChild(manufacturerCountry);
                teapotNode.AppendChild(description);
                teapotNode.AppendChild(imgUrl);

                root.AppendChild(teapotNode);
            }

            _xmlDocument.AppendChild(declaration);
            _xmlDocument.AppendChild(root);
            _xmlDocument.Save(_docPath);
        }

        public List<Teapot>? Deserialize()
        {
            try
            {
                _xmlDocument.Load(_docPath);
            }
            catch (Exception)
            {
                Console.WriteLine("XML file is empty!");
            }

            var root = _xmlDocument.DocumentElement;
            var teapots = new List<Teapot>();

            if (!string.IsNullOrEmpty(_schemaPath))
            {
                XmlValidator.Validate(_docPath, _schemaPath);
            }

            if (root != null)
            {
                foreach (var el in root.ChildNodes)
                {
                    var teapot = new Teapot();
                    var currTeapotXmlDocument = (XmlElement)el;

                    teapot.Id = Convert.ToInt32(currTeapotXmlDocument?.Attributes["id"]?.Value);
                    teapot.Title = currTeapotXmlDocument?.GetElementsByTagName("title")[0]?.InnerText;
                    teapot.Quantity = Convert.ToInt32(currTeapotXmlDocument?.GetElementsByTagName("quantity")[0]?.InnerText);
                    teapot.Price = Convert.ToDouble(currTeapotXmlDocument?.GetElementsByTagName("price")[0]?.InnerText);
                    teapot.Capacity = Convert.ToDouble(currTeapotXmlDocument?.GetElementsByTagName("capacity")[0]?.InnerText);
                    teapot.WarrantyInMonths = Convert.ToInt32(currTeapotXmlDocument?.GetElementsByTagName("warrantyInMonths")[0]?.InnerText);
                    teapot.ManufacturerCountry = currTeapotXmlDocument?.GetElementsByTagName("manufacturerCountry")[0]?.InnerText;
                    teapot.Description = currTeapotXmlDocument?.GetElementsByTagName("description")[0]?.InnerText;
                    teapot.ImgUrl = currTeapotXmlDocument?.GetElementsByTagName("imgUrl")[0]?.InnerText;

                    teapots.Add(teapot);
                }
            }

            return teapots;
        }
    }
}
