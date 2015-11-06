#define TEST_ONLY_UGLY_MARK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeGenerator
{
    public class Method : FragmentBase
    {
        public Method() : base()
        {
            EndLines.Add( CodeLine.EmptyCodeLine );            
        }

        public bool AddMethod( string return_type, string name, Dictionary<string,string> param_list )
        {
            bool result = false;           
            if ( IsLegal(return_type,name, param_list ) )
            {
                string firstline = string.Format( "{0} {1}(",return_type, name );
                if ( null != param_list && 0 != param_list.Count )
                {
                    int over_one_part = 0;

                    foreach ( var item in param_list )
                    {
                        over_one_part += 1;
                        if ( over_one_part > 1 )
                            firstline += ",";
                        firstline     += string.Format( " {0} {1} " , item.Key , item.Value );
                    }
                }
                
                firstline += ")";
                BeginLines.Add( new CodeLine( firstline             , 0 ) );
                BeginLines.Add( new CodeLine( "{"                   , 0 ) );
                EndLines.  Add( new CodeLine( "} // End of " + name , 0 ) );
                result    = true;
            }
            return result;
        }

        // For now, this part is just a design for the code style, not work yet!
        private bool IsLegal( string return_type , string name , Dictionary<string , string> param_list )
        {
            #if TEST_ONLY_UGLY_MARK
            return true;
            #endif

            bool result = false;

            do
            {
                if ( !CppCheckers.instance.IsInbuidType( return_type ) )
                    break;

                if ( !CppCheckers.instance.IsNameLegal(name) )
                    break;

                result = true;
            }
            while ( false );   
                    
            return result;
        }

    }
}
