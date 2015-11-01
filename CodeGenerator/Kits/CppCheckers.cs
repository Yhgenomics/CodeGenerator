using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class CppCheckers
    {
        private CppCheckers()
        {}

        public static CppCheckers instance
        {
            get
            {
                if ( null == instance_ )
                {
                    instance_ = new CppCheckers();
                }
                return instance_;
            }
        }

        public List<string> CppInbuildTypes
        {
            get
            {
                return cpp_inbuild_types_;
            }            
        }

        public bool IsInbuidType(string sometype)
        {
            return cpp_inbuild_types_.Contains( sometype );
        }

        public bool IsNameLegal( string name )
        {
            throw new Exception( "IsNameLegal can not work yet!" );
        }

        private List<string> cpp_inbuild_types_;
        private static CppCheckers instance_ = null;
    }
}
