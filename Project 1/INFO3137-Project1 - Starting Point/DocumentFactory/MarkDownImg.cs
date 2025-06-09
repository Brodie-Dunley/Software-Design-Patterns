using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory
{
    public class MarkDownImg : MarkdownElement
    {
        string fileName;
        string altText;
        string titleText;

        public MarkDownImg(string fileName, string altText, string titleText)
        {
            this.fileName = fileName;
            this.altText = altText;
            this.titleText = titleText;
        }
        public override string ToString() 
        {
            return $"![{this.altText}]({this.fileName} \"{this.titleText}\")";
        }

        //![alt-text](fileName, "title");
    }
}
