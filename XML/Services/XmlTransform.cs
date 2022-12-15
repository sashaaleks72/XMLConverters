using System.Xml.Xsl;

namespace XML.Services
{
    public static class XmlTransform
    {
        public static void TransformXML(string docPath, string stylesPath, string htmlPath)
        {
            var transform = new XslTransform();

            transform.Load(stylesPath);
            transform.Transform(docPath, htmlPath);
        }
    }
}
