
		*** Facade Pattern ***
		
		Componentele principale ale pattern-ului Facade sunt:

		Facade:
		O interfață simplificată care oferă acces la funcționalitatea unui subsistem mai mare.
		Ascunde detaliile și complexitatea subsistemului și oferă o interfață unificată pentru utilizare.
		
		Subsystem (Subsistem):
		Un ansamblu de clase sau interfețe care reprezintă componentele individuale ale sistemului.
		Poate fi complex și să conțină multe clase și interfețe care lucrează împreună pentru a realiza o anumită funcționalitate.
		
		Prin utilizarea pattern-ului Facade, putem simplifica interacțiunea cu un sistem complex, reducând astfel cuplajul dintre clienți și componente și îmbunătățind astfel modularitatea și extensibilitatea sistemului.
		
		using System;

		// Interfață simplificată pentru Facade
		public interface ILibraryFacade
		{
			void PerformAction1();
			void PerformAction2();
		}

		// Implementarea concretă a Facade
		public class LibraryFacade : ILibraryFacade
		{
			private Subsystem1 _subsystem1;
			private Subsystem2 _subsystem2;

			public LibraryFacade()
			{
				_subsystem1 = new Subsystem1();
				_subsystem2 = new Subsystem2();
			}

			public void PerformAction1()
			{
				_subsystem1.Method1();
				_subsystem2.Method2();
				Console.WriteLine("Facade: Executing Action 1");
			}

			public void PerformAction2()
			{
				_subsystem2.Method2();
				Console.WriteLine("Facade: Executing Action 2");
			}
		}

		// Subsistemul 1
		public class Subsystem1
		{
			public void Method1()
			{
				Console.WriteLine("Subsystem1: Method1");
			}
		}

		// Subsistemul 2
		public class Subsystem2
		{
			public void Method2()
			{
				Console.WriteLine("Subsystem2: Method2");
			}
		}

		class Program
		{
			static void Main(string[] args)
			{
				// Utilizarea Facade pentru a accesa funcționalitatea complexă a subsistemului într-un mod simplificat
				ILibraryFacade facade = new LibraryFacade();
				facade.PerformAction1();
				facade.PerformAction2();
			}
		}
