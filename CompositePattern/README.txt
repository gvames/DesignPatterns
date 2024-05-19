
		*** Composite Pattern ***
		
		Pattern-ul Composite este un pattern de design structural care permite compunerea obiectelor în structuri arborescente pentru a reprezenta ierarhii parte-întreg într-un mod uniform. Scopul său este de a permite clienților să trateze obiectele individuale și compuse în mod uniform.

		În esență, Composite-ul permite clienților să trateze obiectele individuale și compuse în același mod, fără a fi nevoie să facă distincții între ele. Acest lucru este posibil prin definirea unei interfețe comune pentru toate componentele, astfel încât acestea să poată fi tratate uniform, indiferent dacă sunt obiecte individuale sau compuse.

		În .NET, Composite Pattern poate fi implementat folosind o interfață comună pentru toate componente, precum și clase concrete pentru obiectele individuale și compuse. Acesta permite compunerea lor într-o structură arborescentă și tratarea lor uniformă de către clienți.
		
		Iată un exemplu simplu de implementare a pattern-ului Composite în .NET:
		
		using System;
		using System.Collections.Generic;

		// Interfață comună pentru toate componente
		public interface IComponent
		{
			void Operation();
		}

		// Implementare a componentelor individuale
		public class Leaf : IComponent
		{
			public void Operation()
			{
				Console.WriteLine("Operation executed in Leaf");
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

			public void Operation()
			{
				Console.WriteLine("Operation executed in Composite");
				foreach (var component in children)
				{
					component.Operation();
				}
			}
		}

		class Program
		{
			static void Main(string[] args)
			{
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
				composite.Operation();
			}
		}
		
		În acest exemplu, avem interfața IComponent care definește operația comună pentru toate componentele. Clasa Leaf reprezintă o componentă individuală, iar clasa Composite reprezintă o componentă compusă care poate conține alte componente. Componentele compuse sunt gestionate folosind o listă de componente copil. Atunci când operația este apelată pe o componentă compusă, aceasta apelază operația pe toate componentele sale copil. Astfel, putem crea și manipula structuri arborescente de componente folosind Composite Pattern.
