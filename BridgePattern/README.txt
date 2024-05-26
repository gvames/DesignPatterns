
	*** Bridge Pattern ***
	
	Pattern-ul Bridge este un pattern de design structural care separă o ierarhie de clase 
	de implementare de ierarhia de clase abstracție, permițându-le să evolueze independent una față de cealaltă.
	Scopul său este de a încorpora abstractizarea și detaliile de implementare în ierarhii separate, 
	ceea ce facilitează schimbările și extensibilitatea în timpul dezvoltării.

	În esență, Bridge-ul este folosit atunci când dorim să evităm legarea rigidă între o abstracție 
	și o implementare, permițându-le să evolueze independent una față de cealaltă. Acest lucru poate fi util 
	în situații în care avem mai multe moduri de a realiza aceeași funcționalitate sau când avem nevoie 
	să schimbăm implementarea fără a afecta codul existent.

	În .NET, Bridge Pattern poate fi implementat folosind interfețe și clase abstracte pentru abstracție 
	și implementare, precum și clase concrete pentru a le implementa. 
	Acesta permite definirea de abstracții și implementări separate și asocierea lor în timpul rulării.

	Iată un exemplu simplu de implementare a pattern-ului Bridge în .NET:
	
	// Interfață pentru implementare
	public interface IImplementation
	{
		void OperationImplementation();
	}

	// Implementare concretă
	public class ConcreteImplementationA : IImplementation
	{
		public void OperationImplementation()
		{
			Console.WriteLine("Operation implemented by ConcreteImplementationA");
		}
	}

	// Alte implementări concrete
	public class ConcreteImplementationB : IImplementation
	{
		public void OperationImplementation()
		{
			Console.WriteLine("Operation implemented by ConcreteImplementationB");
		}
	}

	// Abstracție
	public abstract class Abstraction
	{
		protected IImplementation implementation;

		public Abstraction(IImplementation implementation)
		{
			this.implementation = implementation;
		}

		public abstract void Operation();
	}

	// Clasă de abstracție extinsă
	public class RefinedAbstraction : Abstraction
	{
		public RefinedAbstraction(IImplementation implementation) : base(implementation)
		{
		}

		public override void Operation()
		{
			Console.WriteLine("Executing operation in RefinedAbstraction");
			implementation.OperationImplementation();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			// Crearea implementării
			IImplementation implementationA = new ConcreteImplementationA();
			IImplementation implementationB = new ConcreteImplementationB();

			// Crearea abstracției și asocierea cu implementare
			Abstraction abstractionA = new RefinedAbstraction(implementationA);
			Abstraction abstractionB = new RefinedAbstraction(implementationB);

			// Apelarea operației
			abstractionA.Operation();
			abstractionB.Operation();
		}
	}

	În acest exemplu, avem interfața IImplementation care definește operația de implementare, iar clasele ConcreteImplementationA și ConcreteImplementationB sunt implementări concrete ale acesteia. Avem, de asemenea, o clasă abstractă Abstraction care definește operația pe care o utilizează clientul. Clasa RefinedAbstraction extinde clasa de abstracție și apelează implementarea asociată. Astfel, putem schimba implementarea în timpul rulării, fără a afecta codul clientului, datorită separării dintre abstracție și implementare.