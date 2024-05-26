using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Proxy pattern furnizeaza un substituiest (placeholder) sau un surogat pentru un alt obiect
             * cu scopul de a controla accesul la el.
             *
             * Exista 3 versiuni diferite ale acestui pattern:
             *     1. Remote Proxy -> Controleaza accesul la o resursa exteriora;
             *     2. Virtual Proxy -> Controleaza accesul la o resursa care este expensive a fi creata (caching);
             *     3. Protection Proxy -> Controleaza accesul la o resursa pe baza drepturilor detinute
             *         raporat la acea resursa
             *
             *                        +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+
             *                        | ISubject       |
             *                        +________________+
             *                        | Request()      |
             *                        |                |
             *                        |                |                        
             *                        |                |                        
             *                        +________________+                        
             *                           ^           ^                          
             *                          / \         / \                         
             *                          ‾|‾         ‾|‾                         
             *                           |            ‾‾‾‾‾‾‾‾‾|                
             *              +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+         +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+   
             *              | Real Subject    |         | Proxy             |   
             *              |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾| (has a) |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾|   
             *              | Request()       |<--------| Operation()       |
             *              |                 |         |                   |
             *              +_________________+         +___________________+
             *
             *
             */










          var proxy = new LazyBookParserProxy("...");
            var result = proxy.GetNumPages(); 
        }

        interface IBookParser
        {
            int GetNumPages();
        }

        class BookParser : IBookParser
        {

            public BookParser(string book)
            {
                // Expensive parsing
            }
            public int GetNumPages()
            {
                return new Random().Next();
            }
        }

        class LazyBookParserProxy : IBookParser
        {
            private BookParser _parser = null;
            private string _book = string.Empty;

            public LazyBookParserProxy(string book)
            {
                _book = book;
            }
            public int GetNumPages()
            {

                if (_parser == null) { _parser = new BookParser(_book); }
                return _parser.GetNumPages();
            }

        }
    }


}

