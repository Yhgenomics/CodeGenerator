using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
   public class FragmentBase : IFragment
    {
        public List<IFragment> Children
        {
            get
            {
                return children_;
            }

            set
            {
                children_ = value;
            }
        }

        public int ParentIndent
        {
            get
            {
                return parent_indent_;
            }

            set
            {
                parent_indent_ = value;
            }
        }

        public List<CodeLine> CoreLines
        {
            get
            {
                return core_lines_;
            }

            set
            {
                core_lines_ = value;
            }
        }

        public List<CodeLine> BeginLines
        {
            get
            {
                return begin_lines_;
            }

            set
            {
                begin_lines_ = value;
            }
        }

        public List<CodeLine> EndLines
        {
            get
            {
                return end_lines_;
            }

            set
            {
                end_lines_ = value;
            }
        }

        public string FragmentType
        {
            get
            {
                return fragment_type_;
            }

            set
            {
                fragment_type_ = value;
            }
        }

        public string Name
        {
            get
            {
                return name_;
            }

            set
            {
                name_ = value;
            }
        }

        public virtual void GenerateAll()
        {
            GenerateBegin();
            GenerateContent();
            GenerateEnd();
        }

        public virtual void GenerateBegin()
        {
            OutputCodeLines( BeginLines );
        }

        public virtual void GenerateContent()
        {
            OutputCodeLines( CoreLines );
            foreach (var child in children_)
            {
                child.GenerateAll();
            }            
        }

        public virtual void GenerateEnd()
        {
            OutputCodeLines( EndLines );
        }

        public FragmentBase(int fatherIndent)
        {
            children_ = new List<IFragment>();
            core_lines_ = new List<CodeLine>();
            begin_lines_ = new List<CodeLine>();
            end_lines_ = new List<CodeLine>();
            parent_indent_ = fatherIndent;
        }

        public virtual void OutputCodeLines( List<CodeLine> codeList)
        {
            foreach ( CodeLine oneline in codeList )
            {
                string tab = string.Empty;
                for ( int i = 0 ; i < oneline.LocalIndent + ParentIndent; i++ )
                {
                    tab += "    ";
                }
                Console.WriteLine( tab + oneline.LineContent );
            }
        }

        public virtual IFragment GetChild( string fragmentType , string name )
        {
            foreach(var child in Children)
            {
                if ( child.FragmentType.Equals( fragmentType ) )
                {
                    return child;
                }
            }
            return null;
        }

        private List<IFragment> children_;
        private int parent_indent_;
        private List<CodeLine> core_lines_;
        private List<CodeLine> begin_lines_;
        private List<CodeLine> end_lines_;
        private string name_;
        private string fragment_type_;
    }
}
