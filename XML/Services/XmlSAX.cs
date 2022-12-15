using System.Xml;
using XML.Models;

namespace XML.Services
{
    public static class XmlSAX
    {
        public static void Serialize(string docPath, List<Teapot> teapots)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter xw = XmlWriter.Create(docPath, settings))
            {
                xw.WriteStartDocument(); 
                xw.WriteStartElement("teapots"); 

                foreach (var teapot in teapots)
                {
                    xw.WriteStartElement("teapot");
                    xw.WriteAttributeString("id", teapot.Id.ToString());

                    xw.WriteElementString("title", teapot.Title);
                    xw.WriteElementString("quantity", teapot.Quantity.ToString());
                    xw.WriteElementString("price", teapot.Price.ToString());
                    xw.WriteElementString("imgUrl", teapot.ImgUrl);
                    xw.WriteElementString("description", teapot.Description);
                    xw.WriteElementString("manufacturerCountry", teapot.ManufacturerCountry);
                    xw.WriteElementString("capacity", teapot.Capacity.ToString());
                    xw.WriteElementString("warrantyInMonths", teapot.WarrantyInMonths.ToString());

                    xw.WriteEndElement();
                }

                xw.WriteEndElement();
                xw.WriteEndDocument(); 
                xw.Flush();
            }
        }

        public static List<Teapot> Deserialize(string docPath, string? schemaPath)
        {
            var teapots = new List<Teapot>();

            if (!string.IsNullOrEmpty(schemaPath))
            {
                XmlValidator.Validate(docPath, schemaPath);
            }

            using (XmlReader xr = XmlReader.Create(docPath))
            {
                string element = "";
                Teapot? teapot = null;

                while (xr.Read())
                {
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        element = xr.Name; // the name of the current element
                        if (element == "teapot")
                        {
                            teapot = new Teapot();
                            teapot.Id = int.Parse(xr.GetAttribute("id")!);
                        }
                    }
                    else if (xr.NodeType == XmlNodeType.Text)
                    {
                        switch (element)
                        {
                            case "title":
                                teapot!.Title = xr.Value;
                                break;
                            case "quantity":
                                teapot!.Quantity = Convert.ToInt32(xr.Value);
                                break;
                            case "price":
                                teapot!.Price = Convert.ToDouble(xr.Value);
                                break;
                            case "imgUrl":
                                teapot!.ImgUrl = xr.Value;
                                break;
                            case "description":
                                teapot!.Description = xr.Value;
                                break;
                            case "manufacturerCountry":
                                teapot!.ManufacturerCountry = xr.Value;
                                break;
                            case "capacity":
                                teapot!.Capacity = Convert.ToDouble(xr.Value);
                                break;
                            case "warrantyInMonths":
                                teapot!.WarrantyInMonths = Convert.ToInt32(xr.Value);
                                break;
                        }
                    }
                    else if ((xr.NodeType == XmlNodeType.EndElement) && (xr.Name == "teapot"))
                        teapots.Add(teapot!);
                }

                return teapots;
            }
        }
    }
}
