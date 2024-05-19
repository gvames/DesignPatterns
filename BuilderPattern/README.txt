

		*** Builder Pattern *** (Creational)
		
		1. Single Responability: Procesul de constructie a obiectelor complexe (pizza) este impartit in mai multe clase:
			a. Clasa directorului "Pizza Maker" responsabila doar cu coordonarea constructiei
			b. Clasele constructorului "MargheritaPizzaBuilder" , "CuatroStagioniPizzaBuilder", "DiavolaPizzaBuilder" responsabile doar cu
				construirea diferitelor tipuri de pizza;
		
		2. Open/Close: Putem adauga noi tipuri de pizza prin simpla creare de noi constructori concreti, fara a afecta clasele existente;
		
		3. Dipendency Inversion: Clasa directorului depinde constructorul abstract, iar constructorii concreti depind de aceeasi interfata sau clasa 
								 abstracta. Astfel, constructorii concreti pot fi inlocuiti fara a afecta codul curent;
		
		 Pattern folosit pentru a construi obiecte complexe pas cu pas. Acesta permite crearea unui obiect complex prin specificarea și combinarea succesivă a diferitelor părți componente.
		 
		 Iată o explicație mai detaliată a modului în care funcționează Builder Pattern:

		1. Director (Director): Aceasta este o clasă care controlează procesul de construire a unui obiect complex. Directorul utilizează un constructor abstract pentru a construi obiectul, dar nu știe detalii specifice despre cum sunt construite părțile componente ale acestuia.
		2. Constructor Abstract (Builder): Acesta este un interfețe sau o clasă abstractă care definește metodele necesare pentru a construi diferite părți ale obiectului complex. Constructorul abstract oferă o interfață comună pentru toți constructorii concreți.
		3. Constructor Concret (Concrete Builder): Acestea sunt clase care implementează constructorul abstract și sunt responsabile pentru construirea părților individuale ale obiectului complex. Fiecare constructor concret știe cum să creeze și să asambleze o anumită parte a obiectului final.
		4. Produs (Product): Acesta este obiectul complex care este construit de director folosind constructorul abstract și constructorii concreți. Produsul poate fi obținut de la director după ce construcția este completă.
		
		Builder Pattern este util în situațiile în care obiectele sunt complexe și au mulți parametri de configurat sau combinații posibile de caracteristici. Acesta permite crearea obiectelor pas cu pas, permițând în același timp flexibilitate și izolare a logicii de construcție.

		Un exemplu comun de utilizare a Builder Pattern este în construcția de obiecte de tip mesaj sau de tipărire, unde avem diferite opțiuni pentru formatul, fontul, stilul etc., iar Builder Pattern ne permite să construim obiectul final într-un mod structurat și modular.
		
		using System;
		using System.Collections.Generic;

		// Produsul - Pizza
		public class Pizza
		{
			public string Type { get; set; }
			public string Size { get; set; }
			public List<string> Toppings { get; set; }

			public Pizza()
			{
				Toppings = new List<string>();
			}

			public void Display()
			{
				Console.WriteLine($"Pizza type: {Type}");
				Console.WriteLine($"Pizza size: {Size}");
				Console.WriteLine("Toppings:");
				foreach (var topping in Toppings)
				{
					Console.WriteLine($"- {topping}");
				}
			}
		}

		// Constructorul Abstract
		public interface IPizzaBuilder
		{
			void SetType(string type);
			void SetSize(string size);
			void AddTopping(string topping);
			Pizza GetPizza();
		}

		// Constructorul Concret pentru Margherita Pizza
		public class MargheritaPizzaBuilder : IPizzaBuilder
		{
			private Pizza _pizza;

			public MargheritaPizzaBuilder()
			{
				_pizza = new Pizza();
			}

			public void SetType(string type)
			{
				_pizza.Type = type;
			}

			public void SetSize(string size)
			{
				_pizza.Size = size;
			}

			public void AddTopping(string topping)
			{
				_pizza.Toppings.Add(topping);
			}

			public Pizza GetPizza()
			{
				return _pizza;
			}
		}

		// Constructorul Concret pentru Cuatro Stagioni Pizza
		public class CuatroStagioniPizzaBuilder : IPizzaBuilder
		{
			private Pizza _pizza;

			public CuatroStagioniPizzaBuilder()
			{
				_pizza = new Pizza();
			}

			public void SetType(string type)
			{
				_pizza.Type = type;
			}

			public void SetSize(string size)
			{
				_pizza.Size = size;
			}

			public void AddTopping(string topping)
			{
				_pizza.Toppings.Add(topping);
			}

			public Pizza GetPizza()
			{
				return _pizza;
			}
		}

		// Constructorul Concret pentru Diavola Pizza
		public class DiavolaPizzaBuilder : IPizzaBuilder
		{
			private Pizza _pizza;

			public DiavolaPizzaBuilder()
			{
				_pizza = new Pizza();
			}

			public void SetType(string type)
			{
				_pizza.Type = type;
			}

			public void SetSize(string size)
			{
				_pizza.Size = size;
			}

			public void AddTopping(string topping)
			{
				_pizza.Toppings.Add(topping);
			}

			public Pizza GetPizza()
			{
				return _pizza;
			}
		}

		// Directorul
		public class PizzaMaker
		{
		public void BuildPizza(IPizzaBuilder builder, string size, List<string> toppings)
			{
				builder.SetSize(size);
				foreach (var topping in toppings)
				{
					builder.AddTopping(topping);
				}
			}
		}

		class Program
		{
			static void Main(string[] args)
			{
				// Alegerea constructorului pentru tipul de pizza dorit
				IPizzaBuilder builder;
				Console.WriteLine("Select the type of pizza (1: Margherita, 2: Cuatro Stagioni, 3: Diavola):");
				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						builder = new MargheritaPizzaBuilder();
						pizzaMaker.BuildPizza(builder, "Medium", new List<string> {"Tomato sauce", "Mozzarella cheese"});
						break;
					case "2":
						builder = new CuatroStagioniPizzaBuilder();
						pizzaMaker.BuildPizza(builder, "Large", new List<string> {"Tomato sauce", "Mozzarella cheese", "Ham", "Mushrooms", "Olives", "Artichokes"});
						break;
					case "3":
						builder = new DiavolaPizzaBuilder();
						pizzaMaker.BuildPizza(builder, "Small", new List<string> {"Tomato sauce", "Mozzarella cheese", "Spicy salami"});
						break;
					default:
						Console.WriteLine("Invalid choice. Defaulting to Margherita Pizza.");
						builder = new MargheritaPizzaBuilder();
						pizzaMaker.BuildPizza(builder, "Medium", new List<string> {"Tomato sauce", "Mozzarella cheese"});
						break;
				}


				// Crearea directorului și construcția pizzei
				PizzaMaker pizzaMaker = new PizzaMaker();
				pizzaMaker.BuildPizza(builder);

				// Obținerea pizzei construite
				Pizza pizza = builder.GetPizza();

				// Afișarea pizzei
				Console.WriteLine("Pizza details:");
				pizza.Display();
			}
		}
