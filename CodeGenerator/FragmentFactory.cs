using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class FragmentFactory : IFragmentFactory
    {
        public bool AddFragmentType( IFragment fragment )
        {
            throw new NotImplementedException();
        }

        public IFragment Creat( string type )
        {
            IFragment fragment = null;
            try
            {
                Type matchedType = Type.GetType(type,true);               
                fragment         = ( IFragment ) Activator.CreateInstance( matchedType, null );     
            }
            catch ( TypeLoadException e )
            {
                Console.WriteLine("Type {0} not found - {1}",type,e.Message);
            }
            return fragment;
        }

        public bool HasFragmentType( IFragment type )
        {
            throw new NotImplementedException();
        }

        public bool LoadFragmentMenu()
        {
            throw new NotImplementedException();
        }
    }
}
