using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class Class : FragmentBase
    {
        public Class() : base()
        {
            EndLines.Add( CodeLine.EmptyCodeLine );
        }

        public void AddClass( string name,string basename )
        {
            string class_define = "class " + name;            
            if ( !basename.Equals( string.Empty ) && !(null == basename) )
            {
                class_define += " : public " + basename;
            }
            BeginLines.Add( new CodeLine( class_define , 0 ) );
            BeginLines.Add( new CodeLine( "{" , 0 ) );
            EndLines.Add( new CodeLine( "}; // End of class " + name , 0 ) );
        }

        public void AddAccessModifer( string modifer)
        {
            AccessModifer modfier = new AccessModifer();
            if ( modfier.AddModifer( modifer ) )
            {
                modfier.ParentIndent = this.ParentIndent;
                Children.Add( modfier );
            }           
        }

        public void AddMethod( string return_type , string name , Dictionary<string , string> param_list )
        {
            Method method = new Method();
            if ( method.AddMethod( return_type , name , param_list ) )
            {
                method.ParentIndent = this.ParentIndent + 1;
                Children.Add( method );
            }
            
        }


    }
}
