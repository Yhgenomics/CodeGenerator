using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class CodeLine
    {
        public static string CodeNewLine = "\r\n";
        public static CodeLine EmptyCodeLine
        {
            get
            {
                return new CodeLine( CodeNewLine , 0 );
            }            
        }

        public int LocalIndent
        {
            get
            {
                return local_indent_;
            }
            set
            {
                local_indent_ = value;
            }
        }

        public string LineContent
        {
            get
            {
                return line_content_;
            }
            set
            {
                line_content_ = value;
            }
        }

        private int local_indent_;
        private string line_content_;

        public CodeLine(string lineContent, int localIndent)
        {
            LineContent = lineContent;
            if ( !lineContent.Contains( CodeNewLine ) )
            {
                LineContent += CodeNewLine;
            }
            LocalIndent = localIndent;
        }    
    }
}
