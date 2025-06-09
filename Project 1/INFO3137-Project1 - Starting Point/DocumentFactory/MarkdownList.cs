using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory
{
    public class MarkdownList : MarkdownElement
    {
        string type;
        List<string> listItems;

        public MarkdownList(string type, List<string> listItems)
        {
            this.type = type;
            this.listItems = listItems;
        }
        public override string ToString()
        {
            if (this.type == "Ordered")
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ol>");
                foreach (var item in listItems)
                {
                    sb.AppendLine($"    <li>{item}</li>");
                }
                sb.AppendLine("<ol>");

                return sb.ToString();
            }
            else if (this.type == "Unordered")
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul>");
                foreach (var item in listItems)
                {
                    sb.AppendLine($"    <li>{item}</li>");
                }
                sb.AppendLine("<ul>");

                return sb.ToString();
            }
            else
                return "No list to display";

        }
    }
}
