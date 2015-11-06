using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public interface IRecipeParser
    {
        FragmentManager FragmentRoot    { get;      }       
        FragmentFactory FragmentFactory { get;      }
        string          GuideBookFile   { get; set; }
        string          MaterialPath    { get; set; }

        void Init( string guideBook , string materialPath );
        void MaterialPrepare();
        void GenerateFiles();
        void GenerateFilesByGuideBook();     
    }
}
