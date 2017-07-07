using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace SimpleRenderer
{
    public static class MainRenderer
    {
        public static class Financial
        {
            public static string GenerateBoletoHtml(int bank)
            {
                switch (bank)
                {
                    case 104:
                        throw new Exception("Layout de Boleto HTML não implementado para Banco CAIXA!");
                        break;
                    case 341:
                        throw new Exception("Layout de Boleto HTML não implementado para Banco Itaú!");
                        break;
                    case 999:
                        return Boleto.ConfigureHtml();
                        break;
                    default:
                        throw new Exception("Oh no! :( That's not right!");
                        break;
                }
            }

            private static class Boleto
            {
                public static string ConfigureHtml()
                {
                    var img64 = GenerateBarCode64(GenerateBarCode("848200000018438301602010705212025975746018261224"), ImageFormat.Png);

                    var xDocument = new XDocument(
                        new XDocumentType("html", null, null, null),
                            new XElement("html",
                                new XElement(ConfigureHeader()),
                                new XElement(ConfigureBody(img64))));

                    var settings = new XmlWriterSettings
                    {
                        OmitXmlDeclaration = true,
                        Indent = true,
                        IndentChars = "\t"
                    };

                    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "simpleRendererResult.html");

                    using (var writer = XmlWriter.Create(path, settings))
                    {
                        xDocument.WriteTo(writer);
                    }

                    Process.Start(path);
                    return "";
                }

                private static XElement ConfigureHeader(string style = "table, tr, th, td { border: 0.1px solid #e6e6e6; font-weight: 200; }", string title = "Financial Document", string charset = "ISO-8859-1", string metaName = "Generator", string metaContent = "SimpleRenderer - MIT")
                {
                    return new XElement("head",
                        new XElement("title", title),
                        new XElement("meta",
                            new XAttribute("http-equiv", "Content-Type"),
                            new XAttribute("content", "text/html"),
                            new XAttribute("charset", charset)),
                        new XElement("meta",
                            new XAttribute("name", metaName),
                            new XAttribute("content", metaContent)),
                        new XElement("style",
                            new XAttribute("type", "text/css"),
                            style));
                }

                private static XElement ConfigureBody(string barCode64)
                {
                    return new XElement("body",
                        new XAttribute("text", "#000000"),
                        new XAttribute("bgColor", "#ffffff"),
                        new XAttribute("leftMargin", "10"),
                        new XAttribute("rightMargin", "10"),
                        new XAttribute("topMargin", "10"),
                            new XElement("div",
                                new XAttribute("align", "right"),
                                "Recibo do Pagador"),
                        new XElement("table",
                                    new XAttribute("cellpadding", "5"),
                                    new XAttribute("cellspacing", "0"),
                                    new XAttribute("style", "width: 100%;"),
                                new XElement("tr",
                                new XElement("td",
                                    new XElement("strong",
                                    "{NOME_DO_BANCO}"
                                    )),
                                new XElement("td",
                                    new XAttribute("align", "center"),
                                        new XElement("strong",
                                        "{CODIGO_DO_BANCO}"
                                    )),
                                new XElement("td",
                                    new XAttribute("align", "right"),
                                        new XElement("strong",
                                        "{LINHA_DIGITAVEL_DO_BOLETO}"
                                    )))),
                                    new XElement("div",
                                        new XAttribute("align", "right"),
                                        new XElement("small",
                                    "Autenticação Mecânica - Ficha de Compensação")),
                                    new XElement("img",
                                    new XAttribute("style", "width: 68%"),
                                    new XAttribute("src", barCode64),
                                    new XAttribute("alt", "BarCode"),
                                    new XAttribute("height", "65")));
                }

                public static Image GenerateBarCode(string barCode, int width = 1000, int height = 250)
                {
                    BarcodeLib.Barcode b = new BarcodeLib.Barcode();

                    var img = b.Encode(BarcodeLib.TYPE.Interleaved2of5, barCode.Trim(), Color.Black, Color.White, width,
                        height);

                    #region only tests purposes

                    //// Construct a bitmap from the button image resource.
                    //Bitmap bmp1 = new Bitmap(img, width, height);

                    //// Save the image as a GIF.
                    //bmp1.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test.png"), ImageFormat.Png);

                    #endregion only tests purposes

                    return img;
                }

                public static string GenerateBarCode64(Image image, ImageFormat format)
                {
                    /*
                     * https://devio.wordpress.com/2011/01/13/embedding-images-in-html-using-c/
                     */
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Convert Image to byte[]
                        image.Save(ms, format);
                        byte[] imageBytes = ms.ToArray();

                        // Convert byte[] to base 64 string
                        string base64String = Convert.ToBase64String(imageBytes);

                        return "data:image/png;base64," + base64String;
                    }
                }
            }
        }
    }
}
