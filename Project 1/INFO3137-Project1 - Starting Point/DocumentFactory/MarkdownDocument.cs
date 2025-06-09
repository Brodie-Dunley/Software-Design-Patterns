using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory
{
    public class MarkdownDocument : IDocument
    {
        private string fileName;
        private List<IElement> markdownElements = new List<IElement> { };

        public MarkdownDocument(string fileName)
        {
            this.fileName = fileName;
        }

        //Loop through the list and write to the file
        public void RunDocument() {

            
            using (var writer = new StreamWriter(fileName))
            {
                foreach (IElement markdown in markdownElements)
                    writer.WriteLine(markdown.ToString());
            }

            string fullPathName = Path.GetFullPath(fileName);
            Console.Write(fullPathName);
            System.Diagnostics.Process.Start("chrome.exe", $"\"{fullPathName}\"");
        }

        public void AddElement(IElement element)
        {
            markdownElements.Add(element);
        }
    }
}
