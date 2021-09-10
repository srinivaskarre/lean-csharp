using System;
using System.Collections.Generic;
using System.Text;

namespace lean_csharp
{
    class MainRunner
    {
        static void Main(string[] args)
        {

            /*CollectionsEx collectionEx = new CollectionsEx();
            collectionEx.ArrayListExample();
            collectionEx.DictionaryExample();*/
            Basics basics = new Basics();
            basics.variableDeclarations();
        }
    }
}
