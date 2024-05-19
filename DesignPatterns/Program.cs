using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var obj1 = SingletonClass.GetInstance();
            var obj2 = SingletonClass.GetInstance();

            string msg = obj1 == obj2 ? "sunt identice" : "nu sunt identice";
            Console.WriteLine($"Instantele {msg}");
            Console.ReadKey();
        }


        class SingletonClass
        {
            private static SingletonClass _instance;
            private static readonly object _lock = new object();

            public int PublicProp { get; set; }

            private SingletonClass()
            {
            }

            public static SingletonClass GetInstance()
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonClass();
                    }
                }
                return _instance;
            }
        }

    }
}
