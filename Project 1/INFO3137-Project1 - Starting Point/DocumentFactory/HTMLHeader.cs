using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory
{
    public class HTMLHeader : HTMLElement
    {
        string headerType;
        string headerText;

        public HTMLHeader(string headerType, string headerText) 
        {
            this.headerType = headerType;
            this.headerText = headerText;
        }
        public override string ToString()
        {
            if (this.headerType == "1")
                return $"<h1>{this.headerText}</h1>";
            else if (this.headerType == "2")
                return $"<h2>{this.headerText}</h2>";
            else if (this.headerType == "3")
                return $"<h3>{this.headerText}</h3>";
            else
                return "Invalid header type";

        }
    }
}
