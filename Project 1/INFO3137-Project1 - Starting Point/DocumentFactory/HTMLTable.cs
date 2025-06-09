using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory
{
    public class HTMLTable : HTMLElement
    {
       
        List<string> columns;
        List<List<string>> rows;

        public HTMLTable(List<string> columns, List<List<string>> rows)
        {
            this.columns = columns;
            this.rows = rows;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table>");
            sb.AppendLine("<tr>");
            foreach(var column in columns)
            {
                sb.AppendLine($"<th>{column}</th>");
                sb.AppendLine("\t");
            }
            sb.AppendLine("</tr>");
            
            foreach (var row in rows)
            {
                StringBuilder rowBuilder = new StringBuilder();
                rowBuilder.Append("        ");
                sb.AppendLine("<tr>");
                foreach (var innerRow in row)
                    rowBuilder.Append($"<td>{innerRow}</td>");
                sb.AppendLine(rowBuilder.ToString());
                sb.AppendLine("</tr>");
            }
            
            sb.AppendLine("</table>");

            return sb.ToString();
        }
    }
}
