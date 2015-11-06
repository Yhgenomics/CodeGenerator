using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class DefineGuards : FragmentBase
    {
        public DefineGuards() : base(){}

        public void AddGuardMark( string mark )
        {
            BeginLines.Add( new CodeLine( "#ifndef " + mark             , 0 ) );
            BeginLines.Add( new CodeLine( "#define " + mark             , 0 ) );
            BeginLines.Add( CodeLine.EmptyCodeLine );

            EndLines.  Add( new CodeLine( "#endif // ! End of " + mark  , 0 ) );
        }
        
    }
}
