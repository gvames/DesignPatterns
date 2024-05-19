
		*** Adapter Pattern OR Wrapper***

		Exista 4 patternuri care sunt foarte usor de confundat:
		1. Adapter
		2. Facade
		3. Proxy
		4. Decorator


		
		Pattern-ul Adapter este un pattern de design structural care permite colaborarea între clase cu interfețe incompatibile. Acesta convertește interfața unei clase într-o altă interfață pe care o așteaptă clientul, permițând astfel colaborarea între acestea.

		În .NET, Adapter Pattern este folosit frecvent pentru a permite interoperabilitatea între componente sau module care au interfețe diferite. Acesta poate fi implementat folosind clase sau obiecte care acționează ca un intermediar între client și serviciul pe care îl adaptează. Există două tipuri principale de adaptoare:

		1. Adaptorul de clasă: Acesta utilizează moștenirea pentru a adapta interfața unui obiect la o altă interfață.
		
		// Interfață pentru noua interfață pe care o așteaptă clientul
		public interface ITarget
		{
			void TargetMethod();
		}

		// Implementare a adaptorului de clasă care moștenește clasa serviciului existent și implementează noua interfață
		public class ClassAdapter : ExistingService, ITarget
		{
			public void TargetMethod()
			{
				// Adaptarea apelului către metoda existentă la noua interfață
				base.ExistingMethod();
			}
		}

		class Program
		{
			static void Main(string[] args)
			{
				// Utilizarea adaptorului de clasă pentru a apela metoda dorită de către client
				ITarget adapter = new ClassAdapter();
				adapter.TargetMethod();
			}
		}
		
		În acest exemplu, avem o interfață ITarget care reprezintă noua interfață pe care clientul o așteaptă să fie utilizată. Apoi, definim clasa ClassAdapter, care moștenește clasa ExistingService și implementează interfața ITarget. În metoda TargetMethod a adaptorului de clasă, apelăm metoda ExistingMethod din clasa de bază pentru a adapta apelul la noua interfață.

		În metoda Main, creăm un obiect de tipul ITarget și îl inițializăm cu un obiect de tipul ClassAdapter. Apoi, utilizăm acest adaptor pentru a apela metoda TargetMethod, care va apela în mod indirect metoda ExistingMethod a serviciului existent, fără a cunoaște detalii despre implementarea sa.

		
		2. Adaptorul de obiect: Acesta utilizează compoziția și delegarea pentru a adapta interfața unui obiect la o altă interfață.
		Iată un exemplu simplu de implementare a pattern-ului Adapter în .NET, folosind un adaptor de obiect:
		
		// Interfață pentru serviciul existent
		public interface IExistingService
		{
			void ExistingMethod();
		}

		// Implementare a serviciului existent
		public class ExistingService : IExistingService
		{
			public void ExistingMethod()
			{
				Console.WriteLine("Executând metoda serviciului existent.");
			}
		}

		// Interfață pentru noua interfață pe care o așteaptă clientul
		public interface ITarget
		{
			void TargetMethod();
		}

		// Implementare a adaptorului de obiect care adaptează serviciul existent la noua interfață
		public class Adapter : ITarget
		{
			private readonly IExistingService _existingService;

			public Adapter(IExistingService existingService)
			{
				_existingService = existingService;
			}

			public void TargetMethod()
			{
				// Adaptarea apelului către metoda existentă la noua interfață
				_existingService.ExistingMethod();
			}
		}

		class Program
		{
			static void Main(string[] args)
			{
				// Crearea serviciului existent
				IExistingService existingService = new ExistingService();

				// Crearea adaptorului și pasarea serviciului existent ca parametru
				ITarget adapter = new Adapter(existingService);

				// Utilizarea adaptorului pentru a apela metoda dorită de către client
				adapter.TargetMethod();
			}
		}
		
		În acest exemplu, avem un serviciu existent reprezentat de interfața IExistingService și clasa ExistingService care o implementează. Apoi, definim interfața nouă ITarget, pe care clientul o așteaptă să fie utilizată. Pentru a permite colaborarea între client și serviciul existent, creăm un adaptor de obiect Adapter, care implementează interfața ITarget. Adaptorul primește serviciul existent ca parametru în constructor și adaptează apelul către metoda ExistingMethod la metoda TargetMethod dorită de către client. Astfel, clientul poate utiliza adaptorul pentru a apela metoda dorită, fără a ști despre implementarea concretă a serviciului existent.
