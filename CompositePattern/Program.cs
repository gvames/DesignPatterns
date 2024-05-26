using System;
using System.Collections.Generic;

namespace CompositePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
            *                        +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+
            *                        | Component      |
            *                        +________________+
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
            *              |     Leaf        |       |   Composite       |     |
            *              |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾|       |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾|     |
            *              |   Operation()   |       |    Operation()    |_____|
            *              |                 |       |                   |
            *              |                 |       |                   |
            *              |                 |       |                   |
            *              |                 |       |                   |
            *              +_________________+       +___________________+
             */


            // Crearea componentelor
            Leaf leaf1 = new Leaf();
            Leaf leaf2 = new Leaf();
            Leaf leaf3 = new Leaf();

            // Crearea componentei compuse
            Composite composite = new Composite();
            composite.Add(leaf1);
            composite.Add(leaf2);

            // Adăugarea unui alt composite într-un composite
            Composite subComposite = new Composite();
            subComposite.Add(leaf3);
            composite.Add(subComposite);

            // Apelarea operației pe componenta compusă
            composite.Operation(0); // Nivelul de indentare începe de la 0
        }

        // Interfață comună pentru toate componente
        public interface IComponent
        {
            void Operation(int indentLevel);
        }

        // Implementare a componentelor individuale
        public class Leaf : IComponent
        {
            public void Operation(int indentLevel)
            {
                Console.WriteLine(new String('\t', indentLevel) + "Operation executed in Leaf");
            }
        }

        // Implementare a componentei compuse
        public class Composite : IComponent
        {
            private List<IComponent> children = new List<IComponent>();

            public void Add(IComponent component)
            {
                children.Add(component);
            }

            public void Remove(IComponent component)
            {
                children.Remove(component);
            }

            public void Operation(int indentLevel)
            {
                Console.WriteLine(new String('\t', indentLevel) + "Operation executed in Composite");
                foreach (var component in children)
                {
                    component.Operation(indentLevel + 1); // Crește nivelul de indentare pentru copii
                }
            }
        }
    }
}
