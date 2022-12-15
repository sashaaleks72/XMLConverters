using System.Xml.Linq;
using System.Xml.Schema;

namespace XML.Services
{
    public static class XmlValidator
    {
        public static void Validate(string docPath, string schemaPath)
        {
            var xmlSchema = new XmlSchemaSet();
            var xmlDocument = XDocument.Load(docPath);

            xmlSchema.Add("", schemaPath);

            xmlDocument.Validate(xmlSchema, (o, e) =>
            {
                throw new Exception(e.Message);
            });

            Console.WriteLine("Successfull validation!");
        }
    }
}
