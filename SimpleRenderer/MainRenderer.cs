using System;
using System.Diagnostics;
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
                    var xDocument = new XDocument(
                        new XDocumentType("html", null, null, null),
                            new XElement("html",
                                new XElement(ConfigureHeader()),
                                new XElement(ConfigureBody())));

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

                private static XElement ConfigureBody()
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
                                    )))
                                    //new XElement("table",
                                    //    new XAttribute("width", "666"),
                                    //    new XAttribute("cellspacing", "5"),
                                    //    new XAttribute("cellpadding", "0"),
                                    //    new XAttribute("border", "0"),
                                    //new XElement("tr",
                                    //new XElement("td",
                                    //    new XAttribute("width", "41")))),
                                    //new XElement("table",
                                    //    new XAttribute("width", "666"),
                                    //    new XAttribute("cellspacing", "5"),
                                    //    new XAttribute("cellpadding", "0"),
                                    //    new XAttribute("border", "0"),
                                    //    new XAttribute("align", "default"),
                                    //new XElement("tr",
                                    //new XElement("td",
                                    //    new XAttribute("width", "41"),
                                    //    new XElement("img",
                                    //    new XAttribute("src", "{PATH_LOGO_EMPRESA}"))),
                                    //new XElement("td",
                                    //    new XAttribute("class", "ti"),
                                    //    new XAttribute("width", "455"),
                                    //    "{IDENTIFICAÇÃO}",
                                    //    "{CPF/CNPJ}",
                                    //    new XElement("br"),
                                    //    "{ENDEREÇO}",
                                    //    "{CIDADE_UF"))),
                                    //new XElement("br"),
                                    //new XElement("table",
                                    //    new XAttribute("width", "666"),
                                    //    new XAttribute("cellspacing", "0"),
                                    //    new XAttribute("cellpadding", "0"),
                                    //    new XAttribute("border", "0"),
                                    //    new XElement("tr",
                                    //    new XElement("td",
                                    //    new XAttribute("class", "cp"),
                                    //    new XAttribute("width", "150"),
                                    //    new XElement("span",
                                    //    new XAttribute("class", "campo"),
                                    //    new XElement("img",
                                    //    new XAttribute("src", "{PATH_LOGO_BANCO}"),
                                    //    new XAttribute("width", "150"),
                                    //    new XAttribute("height", "40"),
                                    //    new XAttribute("border", "0")))
                                    ));
                }
            }
        }
    }
}
