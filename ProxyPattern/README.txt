
		*** Proxy Pattern ***
		
		Pattern-ul Proxy este un pattern de design structural care permite controlul accesului la un obiect prin intermediul unui obiect de înlocuire sau de reprezentare. Scopul său este de a oferi o înlocuire sau o reprezentare pentru un alt obiect, permițându-i să controleze accesul la acesta și să ofere funcționalități suplimentare, cum ar fi gestionarea cache-ului, controlul accesului, încărcarea lentă etc.

		Există mai multe tipuri de proxy-uri, inclusiv:

		Proxy simplu: oferă o reprezentare locală a unui obiect remote, permițând controlul accesului și oferind funcționalități suplimentare.
		Proxy virtual: permite încărcarea lentă a unui obiect până când este necesară utilizarea acestuia.
		Proxy de securitate: controlează accesul la un obiect pentru a implementa politici de securitate.
		Proxy de logare: înregistrează informații despre accesul la un obiect pentru scopuri de monitorizare sau depanare.
		În .NET, pattern-ul Proxy poate fi implementat folosind interfețe comune pentru proxy și obiectul real, permițând înlocuirea transparentă a obiectului real cu un proxy. Acest lucru oferă o flexibilitate crescută și separarea responsabilităților între obiectul real și proxy.

		Iată un exemplu simplu de implementare a unui proxy în .NET:
		
		using System;

		// Interfață comună pentru obiectul real și proxy
		public interface ISubject
		{
			void Request();
		}

		// Implementare a obiectului real
		public class RealSubject : ISubject
		{
			public void Request()
			{
				Console.WriteLine("RealSubject: Handling request.");
			}
		}

		// Implementare a proxy-ului
		public class Proxy : ISubject
		{
			private RealSubject realSubject;

			public void Request()
			{
				// Crearea obiectului real la cerere
				if (realSubject == null)
				{
					realSubject = new RealSubject();
				}
				
				// Controlul accesului și delegarea către obiectul real
				Console.WriteLine("Proxy: Handling request.");
				realSubject.Request();
			}
		}

		class Program
		{
			static void Main(string[] args)
			{
				// Utilizarea proxy-ului pentru a accesa obiectul real
				Proxy proxy = new Proxy();
				proxy.Request();
			}
		}
		
		În acest exemplu, avem interfața ISubject care definește operația comună pentru obiectul real și proxy. Clasa RealSubject reprezintă obiectul real, în timp ce clasa Proxy reprezintă proxy-ul. Atunci când este apelată operația Request() pe proxy, acesta controlează accesul și delegă cererea către obiectul real, oferind astfel o interfață de acces controlat la obiectul real.
