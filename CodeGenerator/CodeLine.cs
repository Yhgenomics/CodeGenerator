using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class CodeLine
    {
        public int LocalIndent;
        public string LineContent;
        public CodeLine(string lineContent, int localIndent)
        {
            LineContent = lineContent;
            LocalIndent = localIndent;
        }    
    }
}
