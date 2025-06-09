using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory
{
    public class HTMLFactory : IDocumentFactory
    {
        private static HTMLFactory _instance;

        private HTMLFactory() { }

        public static HTMLFactory Instance
        {
            get
            {
                if( _instance == null )
                    _instance = new HTMLFactory();
                return _instance;
            }
        }
        public IDocument CreateDocument(string fileName)
        {
            return new HTMLDocument(fileName);
        }

        public IElement CreateElement(string elementType, string props)
        {
            var parts = props.Split(';');
            switch (elementType)
            {
                case "Image":
                    return new HTMLImg(parts[0], parts[1], parts[2]);
                case "Header":
                    return new HTMLHeader(parts[0], parts[1]);
                case "List":
                    {
                        string type = parts[0];
                        List<string> listItems = new List<string>();
                        foreach (string item in parts)
                        {
                            listItems.Add(item);
                        }

                        return new HTMLList(type, listItems);
                    }
                case "Table":
                    var tableParts = props.Split(';');
                    List<string> headerParts = new List<string>();
                    List<List<string>> rowParts = new List<List<string>>();

                    foreach (var part in tableParts)
                    {
                        var parts_ = part.Split('$').ToList();
                        var indicator = parts_[0];
                        parts_.RemoveAt(0);
                        if (indicator == "Head")
                        {
                            headerParts.AddRange(parts_);
                        }
                        else if (indicator == "Row")
                        {
                            rowParts.Add(parts_);
                        }

                    }
                    return new HTMLTable(headerParts, rowParts);

            }
            return new HTMLElement();
        }
    }
}
