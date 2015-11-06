using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class AccessModifer : FragmentBase
    {
        public AccessModifer() : base()
        {
            EndLines.Add( CodeLine.EmptyCodeLine );
        }

        public bool AddModifer( string modifer )
        {
            bool    result        = false;
            string  modifer_lower = modifer.ToLower();

            if ( IsLegal( modifer_lower ) )
            {
                CoreLines.Add( new CodeLine( modifer_lower + ":" , 0 ) );
                result = true;
            }
            return result;
        }

        private bool IsLegal( string modifer_lower )
        {
            return modifer_lower.Equals( "public"    ) 
                || modifer_lower.Equals( "private"   ) 
                || modifer_lower.Equals( "protected" );
        }

    }
}
