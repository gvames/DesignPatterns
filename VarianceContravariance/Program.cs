using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace VarianceContravariance
{
    internal class Program
    {
        static void ConsumeBase(Fruit input)
        {

        }
        
        static void ConsumeDerived(Apple input)
        {

        }

        static void Main(string[] args)
        {

            // Contravarianta
            Action<Fruit> af = null;
            Action<Apple> ap = null ;

            af.Invoke(new Fruit());
            af.Invoke(new Apple());
            ap.Invoke(new Fruit());
            ap.Invoke(new Apple());
            af = ap;
            ap = af;


            // Covarianta
            Func<Fruit> ff = null;
            Func<Apple> fa = null;

            Fruit ffout = ff.Invoke();
            Apple ffout1 = ff.Invoke();
            Fruit faout = fa.Invoke();
            Apple faout1 = fa.Invoke();




            // Covarianta

            IProducer<Fruit> ipf = null;
            IProducer<Apple> ipa = null;

            Fruit result = ipf.Produce();
            Fruit result1 = ipa.Produce();
            Apple apple = ipf.Produce();
            Apple apple1 = ipa.Produce();


            IProducer<Fruit> obj1 = ipf;
            IProducer<Fruit> obj2 = ipa;
            IProducer<Apple> obj3 = ipf;
            IProducer<Apple> obj4 = ipa;

            // Contravarianta
            IConsumer<Fruit> icf = null;
            IConsumer<Apple> ica = null;

            IConsumer<Apple> ica1 = ica;
            IConsumer<Apple> ica2 = icf;
            IConsumer<Fruit> icf1 = icf;
            IConsumer<Fruit> icf2 = ica;

            ica.Consume(new Apple());
            ica2.Consume(new Fruit());
            icf.Consume(new Fruit());
            icf.Consume(new Apple());

        }
    }

    class Fruit { }
    class Apple : Fruit { }

    interface IConsumer<in T>
    {
        void Consume(T input);
    }

    interface IProducer<out T>
    {
        T Produce();
    }
}
