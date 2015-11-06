using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace CodeGenerator
{
    public class MessageRecipeParser : IRecipeParser
    {
        public MessageRecipeParser()
        {
            fragment_root_      = new FragmentManager();
            fragment_factory_   = new FragmentFactory();
            guide_book_file_    = string.Empty;
            material_path_      = string.Empty;
            order_list_         = new List<HppFileDescrption>();
        }

        public void Init( string guideBook , string materialPath )
        {
            GuideBookFile   = guideBook;
            MaterialPath    = materialPath;
        }

        public void MaterialPrepare()
        {
            if ( null != order_list_ && !order_list_.Count.Equals( 0 ) )
            {
                order_list_.Clear();
            }

            DirectoryInfo materialFolder = null;

            if ( Directory.Exists( material_path_ ) )
            {
                materialFolder = new DirectoryInfo( material_path_ );
            }
            else
            {
                throw new Exception( "Can not find the Material Path" );
            }

            foreach ( FileInfo nextFile in materialFolder.GetFiles( "*.json" ) )
            {
                string                  jsonString          = File.ReadAllText( nextFile.FullName , Encoding.UTF8 );
                List<ProtocolMetaItem>  classMemberDefine   = JsonConvert.DeserializeObject<List<ProtocolMetaItem>>( jsonString );

                HppFileDescrption       oneFile             = new HppFileDescrption();

                oneFile.ClassMemberList                     = classMemberDefine;
                oneFile.NameSpaceString                     = @"Protocol";
                oneFile.ClassName                           = Path.GetFileNameWithoutExtension( nextFile.FullName );
                oneFile.ParentClassName                     = @"Message";
                oneFile.HeaderDictionary.Add( "iostrem" , false );
                oneFile.HeaderDictionary.Add( "<fstream>" , false );
                oneFile.HeaderDictionary.Add( "json.hpp" , true );

                order_list_.Add( oneFile );
            }
        }

        public void GenerateFiles()
        {
            MaterialPrepare();
            if ( null == order_list_ || order_list_.Count.Equals( 0 ) )
            {
                return;
            }

            foreach ( var fileDesc in order_list_ )
            {
                GenerateProtocolClassFile( fileDesc );
            }
        }

        private void GenerateProtocolClassFile( HppFileDescrption hppFileDescrption )
        {
            fragment_root_.AddChild( new Description() );

            DefineGuards defineGuards = new DefineGuards();
            defineGuards.AddGuardMark( hppFileDescrption.DefineGuards );
            fragment_root_.AddChild( defineGuards );

            Headers headers = new Headers();
            fragment_root_.AddChildTo( defineGuards , headers , 0 );
            foreach ( var item in hppFileDescrption.HeaderDictionary )
            {
                headers.AddHeader( item.Key , item.Value );
            }

            NameSpace nmspace = new NameSpace();
            fragment_root_.AddChildTo( defineGuards , nmspace , 0 );
            nmspace.AddNameSpace( hppFileDescrption.NameSpaceString );

            Class cls = new Class();
            fragment_root_.AddChildTo( nmspace , cls , 1 );
            cls.AddClass( hppFileDescrption.ClassName , hppFileDescrption.ParentClassName );
            cls.AddAccessModifer( "public" );

            Dictionary<string , string> param_list = new Dictionary<string , string>();
            param_list.Add( "int"    , "num" );
            param_list.Add( "string" , "str" );
            param_list.Add( "float"  , "flt" );
            cls.AddMethod( "int" , "method1" , param_list );

            cls.AddAccessModifer( "private" );
            cls.AddMethod( "int" , "method2" , null );

            fragment_root_.GenerateAll();
        }

        public void GenerateFilesByGuideBook()
        {
            throw new NotImplementedException( "need a script design" );
        }

        public FragmentManager FragmentRoot
        {
            get { return    fragment_root_;     }
        }

        public FragmentFactory FragmentFactory
        {
            get { return    fragment_factory_;  }
        }

        public string GuideBookFile
        {
            get { return    guide_book_file_;   }
            set { guide_book_file_   = value;   }
        }

        public string MaterialPath
        {
            get { return    material_path_;     }
            set { material_path_    = value;    }
        }

        private FragmentManager         fragment_root_;
        private FragmentFactory         fragment_factory_;
        private string                  guide_book_file_;
        private string                  material_path_;
        private List<HppFileDescrption> order_list_;

        public class ProtocolMetaItem
        {
            public string name  = null;
            public string type  = null;
            public string value = null; //default value
        }

        public class HppFileDescrption
        {
            public string FileName
            {
                get
                {
                    if ( null == file_name_ || file_name_.Equals( string.Empty )
                        && !( null == class_name_ || class_name_.Equals( string.Empty ) ) )
                    {
                        file_name_ = class_name_ + ".hpp";
                    }
                    else
                    {
                        file_name_ = string.Empty;
                    }
                    return file_name_;
                }
            }

            public string DefineGuards
            {
                get
                {
                    if ( ( null == define_guards_ || define_guards_.Equals( string.Empty ) )
                        && !( null == class_name_ || class_name_.Equals( string.Empty ) ) )
                    {
                        char[] classNameChars = class_name_.ToArray();
                        define_guards_ = string.Empty;
                        int i = 0;
                        for ( ; i < classNameChars.Length - 1; i++ )
                        {
                            define_guards_ += classNameChars[ i ];

                            if ( classNameChars[ i ] >= 'a'
                            && classNameChars[ i ] <= 'z'
                            && classNameChars[ i + 1 ] >= 'A'
                            && classNameChars[ i + 1 ] <= 'Z' )
                            {
                                define_guards_ += '_';
                            }
                        }
                        define_guards_ += classNameChars[ i ];
                        define_guards_ += "_HPP_";
                        define_guards_ = define_guards_.ToUpper();
                    }
                    else
                    {
                        define_guards_ = string.Empty;
                    }
                    return define_guards_;
                }
            }

            public string ClassName
            {
                get { return class_name_;  }
                set { class_name_ = value; }
            }

            public string NameSpaceString
            {
                get
                {
                    if ( null == namespace_string_ )
                    {
                        namespace_string_ = string.Empty;
                    }
                    return namespace_string_;
                }
                set { namespace_string_ = value;  }
            }

            public List<ProtocolMetaItem> ClassMemberList
            {
                get { return class_member_list_;  }
                set { class_member_list_ = value; }
            }

            public string ParentClassName
            {
                get
                {
                    if ( null == parent_class_name_ || parent_class_name_.Equals( string.Empty ) )
                    {
                        parent_class_name_ = string.Empty;
                    }
                    return parent_class_name_;
                }
                set { parent_class_name_ = value; }
            }

            public Dictionary<string , bool> HeaderDictionary
            {
                get
                {
                    if ( null == header_dictionary_ )
                    {
                        header_dictionary_ = new Dictionary<string , bool>();
                    }
                    return header_dictionary_;
                }
            }

            private string file_name_;
            private string define_guards_;
            private string namespace_string_;
            private string class_name_;           
            private string parent_class_name_;

            private List<ProtocolMetaItem>      class_member_list_;
            private Dictionary<string , bool>   header_dictionary_;
        }
    }
}
