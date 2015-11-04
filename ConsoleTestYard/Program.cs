using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenerator;
using System.Reflection;

namespace ConsoleTestYard
{
    class Program
    {
        static void Main( string[] args )
        {
            //ReflectionTest();          
            //CodeTest();
            OrderListTest();
            Console.ReadLine();
        }

        private static void OrderListTest()
        {
            MessageRecipeParser messageClassWriter = new MessageRecipeParser();
            messageClassWriter.Init(string.Empty, @"F:\DreamLand\maraton-protocol\messagetemplates" );
            messageClassWriter.GenerateFiles();
        }

        // Use the fragment dirctly
        static void CodeTest()
        {
            FragmentManager cpp_writer = new FragmentManager();
            cpp_writer.AddChild( new Description() );

            DefineGuards define_guards = new DefineGuards();
            cpp_writer.AddChild( define_guards );

            Headers headers = new Headers();
            cpp_writer.AddChildTo( define_guards , headers , 0 );
            headers.AddHeader( "iostrem" ,false);
            headers.AddHeader( "<fstream>" ,false);
            headers.AddHeader( "json.hpp" , true );            

            NameSpace nmspace = new NameSpace();
            cpp_writer.AddChildTo( define_guards , nmspace , 0 );
            nmspace.AddNameSpace( "demo" );

            Class cls = new Class();
            cpp_writer.AddChildTo( nmspace , cls , 1 );
            cls.AddClass( "FirstClass" ,"ParentClass");
            cls.AddAccessModifer( "public" );
            Dictionary<string , string> param_list = new Dictionary<string , string>();
            param_list.Add( "int" , "num" );
            param_list.Add( "string" , "str" );
            param_list.Add( "float" , "flt" );
            cls.AddMethod( "int" , "method1" , param_list );
            cls.AddAccessModifer( "private" );
            cls.AddMethod( "int" , "method2" , null );

            cpp_writer.GenerateAll();
        }
        // Test for using the fragments in relection way
        static void ReflectionTest()
        {
            FragmentManager cppWriter = new FragmentManager();

            FragmentFactory fragmentFactory = new FragmentFactory();

            IFragment codeDescription = fragmentFactory.Creat( "CodeGenerator.Description" );
            cppWriter.AddChild( codeDescription );

            IFragment defineGuards = fragmentFactory.Creat( "CodeGenerator.DefineGuards" );
            MethodInfo tempMethod = defineGuards.GetType().GetMethod( "AddGuardMark" );
            List<object> lis = new List<object>();
            lis.Add( "SOME_HPP_" );
            tempMethod.Invoke( defineGuards , lis.ToArray() );
            cppWriter.AddChild( defineGuards );

            IFragment headers = fragmentFactory.Creat( "CodeGenerator.Headers" );
            MethodInfo addHeader = headers.GetType().GetMethod( "AddHeader" );
            List<object> headername = new List<object>();
            headername.Add( "<iostream>" );
            headername.Add( false );
            addHeader.Invoke( headers , headername.ToArray() );
            headername.Clear();
            headername.Add( "fstream" );
            headername.Add( false );
            addHeader.Invoke( headers , headername.ToArray() );
            headername.Clear();
            headername.Add( "json.hpp" );
            headername.Add( true );
            addHeader.Invoke( headers , headername.ToArray() );
            headername.Clear();
            cppWriter.AddChildTo( defineGuards , headers , 0 );

            IFragment NameSpace = fragmentFactory.Creat( "CodeGenerator.NameSpace" );
            MethodInfo addNS = NameSpace.GetType().GetMethod( "AddNameSpace" );
            lis.Clear();
            lis.Add( "maratonprotocol" );
            addNS.Invoke( NameSpace , lis.ToArray() );
            cppWriter.AddChildTo( defineGuards , NameSpace , 0 );

            IFragment ClassName = fragmentFactory.Creat( "CodeGenerator.Class" );
            MethodInfo addClass = ClassName.GetType().GetMethod( "AddClass" );
            lis.Clear();
            lis.Add( "MessageXXX" );
            lis.Add( "Message" );
            addClass.Invoke( ClassName , lis.ToArray() );
            cppWriter.AddChildTo( NameSpace , ClassName , 1 );
            cppWriter.GenerateAll();
        }
    }
}
