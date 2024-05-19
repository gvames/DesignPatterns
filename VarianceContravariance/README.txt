

		*** Variance & Contravariance ***		
		

			using System.Collections.Generic;
			using System.Linq;
			using System.Net.Http.Headers;
			using System.Text;
			using System.Threading.Tasks;

			namespace Variance_Contravariance
			{
				internal class Program
				{
					static void Main(string[] args)
					{
						Base x = new Base();
						Base Y = new Derived();
						Derived z = new Derived();
					   // Derived w = new Base(); /* Nu compileaza*/
						x.DoSometing();
						Y.DoSometing();
						z.DoSometing();
						z.DoMore();


						// Covariance
						IProducer<Base> producerOfBase = null;
						Base a = producerOfBase.Produce();
						// Derived b = producerOfBase.Produce(); /* Nu compileaza */

						IProducer<Derived> prodOfDerived = null;
						Base a1 = prodOfDerived.Produce();
						Derived b = prodOfDerived.Produce();

						/*  Derived : Base
						 *  IMPLICA
						 *  IProducer<Derived> : IProducer<Base>  
						 *  Variant
						 */

						IProducer<Base> p = producerOfBase;
						IProducer<Base> q = prodOfDerived;
						IProducer<Derived> r = prodOfDerived;
						//  IProducer<Derived> t = producerOfBase; /* Nu compileaza */

						// Contravariance
						IConsumer<Base> consumerOfBase = null;
						consumerOfBase.Consume( new Base());
						consumerOfBase.Consume( new Derived());

						IConsumer<Derived> consOfDerived = null;
						consOfDerived.Consume( new Derived());
						// consOfDerived.Consume(new Base()); /* Nu copileaza */

					   /*   Derived : Base
						*   IMPLICA
						*   IConsumer<Base> : IConsumer<Derived>
						*   Contravariant
						*/

						IConsumer<Base> g = consumerOfBase;
						//IConsumer<Base> h = consOfDerived;
						IConsumer<Derived> e = consOfDerived;
						IConsumer<Derived> k = consumerOfBase; /* Because consumer of base
																* is expecting base object and
																* and we can pass the derived
																* object in.
																*/

						Console.ReadKey();
					}
				}

				public class Base
				{
					public virtual void DoSometing() => Console.WriteLine($"Doing from: {this.GetType().Name}");
				}

				public class Derived : Base
				{
					public override void DoSometing() => Console.WriteLine($"Doing from: {this.GetType().Name}");

					public void DoMore() => Console.WriteLine($"Doing more from: {this.GetType().Name}");
				}

				public interface IProducer<out T>
				{
					T Produce();
				}

				public interface IConsumer<in T>
				{
					void Consume(T input);
				}
			}

	

