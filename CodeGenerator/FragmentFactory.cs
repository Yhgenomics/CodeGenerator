using System;
using System.Collections.Generic;
using System.Linq;
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

        public IFragment Creat( string type , string name )
        {
            IFragment fragment = null;
            try
            {
                Type matchedType = Type.GetType(type,true);
                Object[] inli = new Object[2];
                inli[0] = "TESTTEST_HPP_";
                inli[1] = 1;

                fragment = ( IFragment ) Activator.CreateInstance( matchedType, inli );
            }
            catch ( TypeLoadException e )
            {
                Console.WriteLine("Damn Type {0} not found - {1}",type,e.Message);
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
