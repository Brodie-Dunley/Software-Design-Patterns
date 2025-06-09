using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory
{

    public class HTMLDocument : IDocument
    {
        private string fileName;
        private List<IElement> hTMLElements = new List<IElement> { };

        public HTMLDocument(string fileName)
        {
            this.fileName = fileName;
        }
        public void RunDocument() {
           
            using (var writer = new StreamWriter(fileName))
            {
                foreach(IElement html in hTMLElements) 
                    writer.WriteLine(html.ToString());
            }
            string fullPathName = Path.GetFullPath(fileName);
            System.Diagnostics.Process.Start("chrome.exe", $"\"{fullPathName}\"");
        }

        public void AddElement(IElement element)
        {
            this.hTMLElements.Add(element);
        }

    }
}
