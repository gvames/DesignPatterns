
		*** Abstract Factory  Pattern *** (Creational)
		(Open Close Priciple & Liskov Substitution Principle)

		Abstract Factory Pattern reprezinta un set de Factory Methods.
		De fapt Factory Patern se folosete de Factory Methods.
		Se poate observa ca Factory Method creaza un singur obiect in timp ce Abstract Factory Pattern creaza o familie de obiecte.
			
		
		
		Diferența principală între Abstract Factory și Factory Method constă în nivelul de abstractizare și complexitatea lor.

		În esență, Factory Method se concentrează pe crearea unui singur obiect, în timp ce Abstract Factory se concentrează pe crearea unei familii de obiecte legate între ele. Ambele pattern-uri oferă o abstracție în procesul de creare a obiectelor, permițând o mai mare flexibilitate și extensibilitate în proiectare.
		
		Un exemplu comun în .NET este utilizarea Abstract Factory pentru a crea diferite tipuri de conexiuni la baze de date în funcție de un anumit context sau configurație. De exemplu, o fabrică abstractă pentru baze de date ar putea avea metode pentru a crea obiecte de tip conexiune SQL sau conexiune Oracle, iar implementările concrete ale acestei fabrici ar furniza logica reală pentru a crea aceste conexiuni.

		Utilizarea Abstract Factory în .NET oferă avantaje precum izolarea codului client de clasele concrete ale obiectelor și ușurința înlocuirii întregilor familii de obiecte, fără a afecta codul client. De asemenea, acesta promovează principiile de design SOLID, cum ar fi Principiul Deschis/Închis și Principiul Substituirii Liskov.
		
		1. Factory Method Pattern:
		Factory Method este un pattern simplu care definește o interfață pentru crearea unui obiect, dar lasă subclasele să decidă clasa concretă a obiectului care va fi instantiat.
		În Factory Method, o clasă de bază are o metodă abstractă care returnează un obiect al unei clase derivate. Subclasele pot suprascrie această metodă pentru a instantia diferite tipuri de obiecte.
		Este adecvat pentru situații în care o clasă cunoaște tipul de obiecte pe care le va crea, dar delegă procesul de creare a acestor obiecte subclaselor.
		
		2. Abstract Factory Pattern:
		Abstract Factory este un pattern mai complex care furnizează o interfață pentru crearea unei familii de obiecte conexe sau dependente, fără a specifica clasele concrete ale acestor obiecte.
		În Abstract Factory, există o interfață abstractă pentru fabrică care definește metode abstracte pentru crearea fiecărui tip de obiect. Aceste metode sunt implementate de fabricile concrete care produc obiecte care corespund unui anumit tip.
		Este utilizat atunci când un sistem trebuie să fie independent de modul în care sunt create, compuse și reprezentate obiectele sale.
				
		
		using System;

		// Interfața abstractă pentru fabrica de conexiuni la baze de date
		public interface IDatabaseFactory
		{
			IDbConnection CreateConnection();
			IDbCommand CreateCommand();
		}

		// Clasa abstractă pentru conexiunile la baze de date
		public interface IDbConnection
		{
			void Open();
			void Close();
		}

		// Clasa abstractă pentru comenzile bazate pe conexiune
		public interface IDbCommand
		{
			void Execute();
		}

		// Implementarea fabricii concrete pentru conexiunile la baze de date SQL
		public class SqlConnectionFactory : IDatabaseFactory
		{
			public IDbConnection CreateConnection()
			{
				return new SqlConnection();
			}

			public IDbCommand CreateCommand()
			{
				return new SqlCommand();
			}
		}

		// Implementarea fabricii concrete pentru conexiunile la baze de date Oracle
		public class OracleConnectionFactory : IDatabaseFactory
		{
			public IDbConnection CreateConnection()
			{
				return new OracleConnection();
			}

			public IDbCommand CreateCommand()
			{
				return new OracleCommand();
			}
		}

		// Implementarea clasei de conexiune SQL
		public class SqlConnection : IDbConnection
		{
			public void Open()
			{
				Console.WriteLine("SQL Connection opened.");
			}

			public void Close()
			{
				Console.WriteLine("SQL Connection closed.");
			}
		}

		// Implementarea clasei de conexiune Oracle
		public class OracleConnection : IDbConnection
		{
			public void Open()
			{
				Console.WriteLine("Oracle Connection opened.");
			}

			public void Close()
			{
				Console.WriteLine("Oracle Connection closed.");
			}
		}

		// Implementarea clasei de comandă SQL
		public class SqlCommand : IDbCommand
		{
			public void Execute()
			{
				Console.WriteLine("SQL Command executed.");
			}
		}

		// Implementarea clasei de comandă Oracle
		public class OracleCommand : IDbCommand
		{
			public void Execute()
			{
				Console.WriteLine("Oracle Command executed.");
			}
		}

		// Clientul care utilizează fabrica abstractă
		public class Client
		{
			private IDatabaseFactory _factory;

			public Client(IDatabaseFactory factory)
			{
				_factory = factory;
			}

			public void Run()
			{
				IDbConnection connection = _factory.CreateConnection();
				IDbCommand command = _factory.CreateCommand();

				connection.Open();
				command.Execute();
				connection.Close();
			}
		}

		class Program
		{
			static void Main(string[] args)
			{
				// Utilizare pentru conexiuni la baze de date SQL
				Client sqlClient = new Client(new SqlConnectionFactory());
				sqlClient.Run();

				// Utilizare pentru conexiuni la baze de date Oracle
				Client oracleClient = new Client(new OracleConnectionFactory());
				oracleClient.Run();
			}
		}
		
		Acest exemplu ilustrează modul în care se pot crea diferite tipuri de conexiuni la baze de date (SQL și Oracle) folosind Abstract Factory. Clientul (Client) utilizează fabrica abstractă (IDatabaseFactory) pentru a crea conexiunea și comanda adecvată în funcție de implementarea specifică a fabricii (SqlConnectionFactory sau OracleConnectionFactory). Astfel, codul clientului este izolat de clasele concrete ale obiectelor și poate fi ușor adaptat pentru a folosi alte tipuri de conexiuni la baze de date fără a modifica logica clientului.

