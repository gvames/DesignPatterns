using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

