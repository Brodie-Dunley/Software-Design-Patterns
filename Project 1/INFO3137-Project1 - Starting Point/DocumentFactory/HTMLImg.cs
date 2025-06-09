using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory
{
    public class HTMLImg : HTMLElement
    {
        string fileName;
        string altText;
        string titleText;

        public HTMLImg(string fileName, string altText, string titleText) 
        {
            this.fileName = fileName;
            this.altText = altText;
            this.titleText = titleText;
        }
        public override string ToString()
        {
            return $"<img alt=\"{this.altText}\" title = \" {this.titleText}\" src = \" {this.fileName}\"/>";
        }
    }
}
