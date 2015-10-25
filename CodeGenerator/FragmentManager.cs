using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class FragmentManager : FragmentBase
    {        
        public void AddDefineGuard(int startLevel)
        {
            DefineGuards dfg = new DefineGuards("TEST_HPP_",startLevel);
            this.Children.Add(dfg);            
        }

        public FragmentManager( int indent ) : base( indent )
        {   
            AddDefineGuard(ParentIndent + 1);
        }

    }
}
