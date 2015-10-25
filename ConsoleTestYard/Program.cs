using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator;

namespace ConsoleTestYard
{
    class Program
    {
        static void Main( string[] args )
        {
            //FragmentManager onetest = new FragmentManager(0);
            //onetest.GenerateAll();

            FragmentFactory fragmentFactory = new FragmentFactory();
            IFragment test = fragmentFactory.Creat( "CodeGenerator.DefineGuards" , "alpha guards" );
            test.GenerateAll();
            Console.ReadLine();
        }
    }
}
