using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class Headers: FragmentBase
    {
        public Headers() : base()
        {
            EndLines.Add( CodeLine.EmptyCodeLine );
        }

        public void AddHeader( string filename,bool islocal )
        {
            if ( filename.Contains( "\"" ) || filename.Contains( "<" ) )
            {
                BeginLines.Add( new CodeLine( "#include "   + filename        , 0 ) );
            }
            else if ( islocal )
            {
                BeginLines.Add( new CodeLine( "#include \"" + filename + "\"" , 0 ) );
            }
            else
            {
                BeginLines.Add( new CodeLine( "#include <"  + filename + ">"  , 0 ) );
            }                       
        }
        
    }
}
