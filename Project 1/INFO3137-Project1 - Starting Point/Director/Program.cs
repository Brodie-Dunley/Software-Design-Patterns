using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DocumentFactory;

namespace Director
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] commands;
            var list = File.ReadAllText("CreateDocumentScript.txt");
            commands = list.Split('#');
            IDocumentFactory factory = null;
            IDocument document = null;

            foreach (var command in commands)
            {
                
                var strippedCommand = Regex.Replace(command, @"\t|\n|\r", "");
                var commandList = strippedCommand.Split(':');
                switch (commandList[0])
                {
                    case "Document":
                        var commandSplit = commandList[1].Split(';');
                        string docType = commandSplit[0];
                        string fileName = commandSplit[1];

                        if (docType == "Markdown")
                        {
                            factory = MarkdownFactory.Instance;
                            document = factory.CreateDocument(fileName);
                        }
                        else if(docType == "Html")
                        {
                            factory = HTMLFactory.Instance;
                            document = factory.CreateDocument(fileName);
                        }
                        else
                        {
                            throw new Exception("Unknown document type: " + docType);
                        }
                            break;
                    case "Element":
                        var elementType = commandList[1];
                        var elementData = commandList[2];

                        IElement element = factory.CreateElement(elementType, elementData);
                        document.AddElement(element);
                        break;
                    case "Run":
                        // Your document running code goes here
                        document.RunDocument();
                        break;
                    default:
                        break;
                }
            }
        }//end of main

    }
}
