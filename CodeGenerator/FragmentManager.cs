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
            DefineGuards dfg = new DefineGuards();
            this.Children.Add(dfg);            
        }

        public void AddChild(IFragment child)
        {
            this.Children.Add( child );
        }

        public void AddChildTo( IFragment parent , IFragment child ,int indentOffset =0)
        {
            child.ParentIndent= parent.ParentIndent+indentOffset;           
            parent.Children.Add( child );            
        }

        public FragmentManager() : base()
        {}
    }
}
