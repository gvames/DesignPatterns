
		*** Decorator Pattern ***
		
		Principiul de bază al pattern-ului Decorator este încapsularea unui obiect într-un alt obiect de tip Decorator care oferă aceeași interfață ca și obiectul inițial. Astfel, Decorator-ul adaugă sau modifică comportamentul obiectului inițial prin adăugarea sau suprascrierea metodelor acestuia, păstrând în același timp funcționalitatea existentă.
		
		omponentele principale ale pattern-ului Decorator sunt:

		1. Component (Componentă):
		Interfața sau clasa abstractă care definește funcționalitatea de bază pe care Decorator-urile o extind sau o modifică.
		
		2. ConcreteComponent (Componentă Concretă):
		Implementarea concretă a interfeței sau clasei Component, care oferă funcționalitatea de bază.
		
		3. Decorator:
		Clasa abstractă care implementează interfața sau moștenește clasa Component și conține o referință la un obiect de tip Component.
		Adaugă sau modifică comportamentul Componentei de bază.
		
		4. ConcreteDecorator (Decorator Concret):
		Implementarea concretă a Decorator-ului, care adaugă sau modifică comportamentul Componentei de bază.
		
		În acest exemplu:

		Interfața ICoffee reprezintă componenta de bază, care definește metode pentru a obține descrierea cafelei și costul acesteia.
		Clasa SimpleCoffee este o implementare concretă a interfeței ICoffee, reprezentând o cafea simplă.
		Clasa abstractă CoffeeDecorator este un decorator abstract, care conține o referință la o instanță de ICoffee.
		Clasele MilkDecorator și SugarDecorator sunt decoratori concreți care adaugă funcționalități suplimentare la cafea (lapte și zahăr) și modifică comportamentul metodelor din componenta de bază pentru a reflecta aceste modificări.
		În Main(), se crează o cafea simplă și se adaugă succesiv decoratori pentru a adăuga lapte și zahăr, obținând astfel descrierea și costul final al cafelei decorate.
		
		using System;

		// Interfața pentru componenta de bază
		public interface ICoffee
		{
			string GetDescription();
			double GetCost();
		}

		// Implementarea concretă a componentei de bază
		public class SimpleCoffee : ICoffee
		{
			public string GetDescription()
			{
				return "Cafea simplă";
			}

			public double GetCost()
			{
				return 1.0;
			}
		}

		// Decorator abstract
		public abstract class CoffeeDecorator : ICoffee
		{
			protected ICoffee _coffee;

			public CoffeeDecorator(ICoffee coffee)
			{
				_coffee = coffee;
			}

			public virtual string GetDescription()
			{
				return _coffee.GetDescription();
			}

			public virtual double GetCost()
			{
				return _coffee.GetCost();
			}
		}

		// Decorator concret - adaugă lapte la cafea
		public class MilkDecorator : CoffeeDecorator
		{
			public MilkDecorator(ICoffee coffee) : base(coffee)
			{
			}

			public override string GetDescription()
			{
				return $"{_coffee.GetDescription()}, cu lapte";
			}

			public override double GetCost()
			{
				return _coffee.GetCost() + 0.5;
			}
		}

		// Decorator concret - adaugă zahăr la cafea
		public class SugarDecorator : CoffeeDecorator
		{
			public SugarDecorator(ICoffee coffee) : base(coffee)
			{
			}

			public override string GetDescription()
			{
				return $"{_coffee.GetDescription()}, cu zahăr";
			}

			public override double GetCost()
			{
				return _coffee.GetCost() + 0.2;
			}
		}

		class Program
		{
			static void Main(string[] args)
			{
				// Crearea unei cafele simple
				ICoffee coffee = new SimpleCoffee();
				Console.WriteLine(coffee.GetDescription()); // Output: "Cafea simplă"
				Console.WriteLine($"Cost: {coffee.GetCost()}"); // Output: "Cost: 1"

				// Adăugarea laptelui la cafea
				coffee = new MilkDecorator(coffee);
				Console.WriteLine(coffee.GetDescription()); // Output: "Cafea simplă, cu lapte"
				Console.WriteLine($"Cost: {coffee.GetCost()}"); // Output: "Cost: 1.5"

				// Adăugarea zahărului la cafea
				coffee = new SugarDecorator(coffee);
				Console.WriteLine(coffee.GetDescription()); // Output: "Cafea simplă, cu lapte, cu zahăr"
				Console.WriteLine($"Cost: {coffee.GetCost()}"); // Output: "Cost: 1.7"
			}
		}
