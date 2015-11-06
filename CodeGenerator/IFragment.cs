using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public interface IFragment
    {
        List<CodeLine>  CoreLines       { get; set; }
        List<CodeLine>  BeginLines      { get; set; }
        List<CodeLine>  EndLines        { get; set; }
        int             ParentIndent    { get; set; }
        List<IFragment> Children        { get; set; }
        string          FragmentType    { get; set; }
        string          Name            { get; set; }

        void GenerateBegin();
        void GenerateEnd();
        void GenerateContent();
        void GenerateAll();

        IFragment GetChild(string fragmentType, string name);
    }
}
