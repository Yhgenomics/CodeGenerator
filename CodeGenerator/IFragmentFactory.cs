using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public interface IFragmentFactory
    {
        IFragment Creat( string type );
        bool LoadFragmentMenu();
        bool AddFragmentType( IFragment fragment);
        bool HasFragmentType( IFragment type);
    }
}
