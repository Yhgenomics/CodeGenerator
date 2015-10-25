using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class DefineGuards : FragmentBase
    {
        public DefineGuards( int indent ) : base( indent )
        {
        }

        public DefineGuards( string mark , int indent ) : base( indent )
        {
            AddGuardMark( mark );
        }

        public void AddGuardMark( string mark )
        {
            BeginLines.Add( new CodeLine( "#ifndef " + mark , 0 ) );
            BeginLines.Add( new CodeLine( "#define " + mark , 0 ) );

            EndLines.Add( new CodeLine( "#endif // ! End of " + mark , 0 ) );
        }
        
    }
}
