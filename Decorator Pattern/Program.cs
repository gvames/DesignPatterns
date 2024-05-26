using System;
using System.Threading;

namespace Decorator_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {


            /* Un decorator "ARE (has-a)" si "ESTE (is-a)" o componenta
             * Acest pattern adauga responsabilitate noua unui obiect in mod DINAMIC (la runtime)!
             * Ofera o metoda flexibila alternativa de "subclassing" pentru extinderea functionalitatii; 
             *
             *
             *                       +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+
             *                       | Component      |
             *                       +________________+
            *                        |   Operation()  |
            *                        |                |<-----------------------+
            *                        |                |                        |
            *                        |                |                        |
            *                        +________________+                        |
            *                           ^           ^                          |
            *                          / \         / \                         |
            *                          ‾|‾         ‾|‾                         |
            *                           |            ‾‾‾‾‾‾‾‾‾|                |
            *              +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+       +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+     |
            *              |ConcreteComponent|       |   Decorator       |     |
            *              |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾|       |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾|     |
            *              |   Operation()   |       |    Operation()    |_____|
            *              |                 |       |                   |
            *              +_________________+       +___________________+
            *                                                   ^
            *                                                  / \
            *                                                  ‾|‾
            *                                        +-------------------+
            *                                        | ConcreteDecorator |
            *                                        |                   |
            *                                        |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾|
            *                                        |  Operation()      |
            *                                        |                   |
            *                                        +-------------------+
            *                                    
            */

            // Crearea unei instanțe a componentei de bază și decorarea acesteia
            IComponent ceai = new Ceai();
            ceai = new CeaiCuZaharDecorator(ceai);
            ceai = new CeaiInCeascaAlbaDecorator(ceai);

            Console.WriteLine(ceai.GetDescription);
            Console.WriteLine($"Cost total: {ceai.GetCost} lei");
            Console.ReadKey();

        }

        interface IComponent
        {
            string GetDescription { get; }
            int GetCost { get; }
        }

        abstract class ComponentDecorator : IComponent
        {
            protected IComponent _component;

            public ComponentDecorator(IComponent component)
            {
                _component = component;
            }

            public virtual string GetDescription => _component.GetDescription;

            public virtual int GetCost => _component.GetCost;
        }

        class Ceai : IComponent /* Componenta de bază */
        {
            public string GetDescription => "Ceai";
            public int GetCost => 2;
        }

        class CeaiCuZaharDecorator : ComponentDecorator
        {
            public CeaiCuZaharDecorator(IComponent component) : base(component) { }

            public override string GetDescription => _component.GetDescription + " & zahar";

            public override int GetCost => _component.GetCost + 2;
        }

        class CeaiInCeascaAlbaDecorator : ComponentDecorator
        {
            public CeaiInCeascaAlbaDecorator(IComponent component) : base(component) { }

            public override string GetDescription => _component.GetDescription + " & ceasca alba";

            public override int GetCost => _component.GetCost + 1;
        }
    }
}
