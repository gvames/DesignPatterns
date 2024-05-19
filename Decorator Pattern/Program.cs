using System;

namespace Decorator_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {


            /* Un decorator "ARE (has-a)" si "ESTE (is-a)" o componenta
             * Acest pattern adauga responsabilitate noua unui obiect in mod DINAMIC (la runtime)!
             * Ofera o metoda flexibila alternativa de "subclassing" pentru extinderea functionalitatii; 
             */
            var FinalDescription =new CeaiInCeascaAlba<IComponent>(new CeaiCuZahar<IComponent>(new Ceai()));
            Console.WriteLine(FinalDescription.GetDescription);
            Console.ReadKey();

        }

        interface IComponent
        {
            string GetDescription { get; }
            int GetCost { get; }
        }

        interface IComponentDecorator<T> where T: IComponent
        {
            T Component { get; }
        }

        class Ceai : IComponent /* Componenta */
        {
            public string GetDescription => "Ceai";
            public int GetCost => 2;
        }

        class CeaiCuZahar<T> : IComponent,IComponentDecorator<T> where T : IComponent
        {
            public T Component { get; }

            public string GetDescription => Component.GetDescription + " & zahar";

            public int GetCost => Component.GetCost + 2;

            public CeaiCuZahar(T component)
            {
                Component = component;
            }            
        }

        class CeaiInCeascaAlba<T> : IComponent, IComponentDecorator<T> where T : IComponent
        {
            public T Component { get; }

            public string GetDescription => Component.GetDescription + " & ceasca alba";

            public int GetCost => Component.GetCost + 1;

            public CeaiInCeascaAlba(T component)
            {
                Component = component;
            }
        }
    }
}
