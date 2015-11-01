using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class NameSpace : FragmentBase
    {
        public NameSpace() : base()
        {
            EndLines.Add( CodeLine.EmptyCodeLine );
        }

        public void AddNameSpace( string sapcename )
        {
            BeginLines.Add( new CodeLine( "namesapce " + sapcename , 0 ) );
            BeginLines.Add( new CodeLine( "{" , 0 ) );
            EndLines.Add( new CodeLine( "} // End of namespace " + sapcename , 0 ) );
        }

    }
}
