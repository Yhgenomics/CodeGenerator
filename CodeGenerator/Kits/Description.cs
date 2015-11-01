using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class Description : FragmentBase
    {
        public Description() : base()
        {
            AddDescription();
        }

        public void AddDescription()
        {
            BeginLines.Add( new CodeLine( "/***************************" , 0 ) );
            BeginLines.Add( new CodeLine( "DEMO ONLY this part will be in a config file later" , 0 ) );
            BeginLines.Add( new CodeLine( "description:" , 0 ) );
            BeginLines.Add( new CodeLine( "author:" , 0 ) );
            BeginLines.Add( new CodeLine( "***************************/" , 0 ) );

            EndLines.Add( CodeLine.EmptyCodeLine );
        }

    }
}
