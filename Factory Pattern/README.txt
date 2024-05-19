

	Exista 3 versiuni ale acestui pattern:
		1. Simple Factory - lumea zice ca acesta nu este chiar un pattern
		2. Factory Method
		3. Abstract Factory

		*** Factory Method PAttern ***

		Cand ai nevoie sa instantiezi un obiect, se poate incapsula acea instantiere,
		astfel incat, aceasta instantiere sa fie uniforma (identica) in toate locurile unde este nevoie 
		de ea.
		1. Factory-ul devine in acest fel responsabil cu instantierea obiectului de care ai nevoie.
		2. Factory-ul este necesar atunci cand nu stim de la bun inceput despre ce fel de tip de obiect avem nevoie. 
			Acesta poate varia functie de o anumita logica. Aceasta logica este incapsulata in Factory.



			
		*** Factory Pattern *** (Creational)
		1. Open Close Principle
		2. Liskov Substitution
		3. Dependency Inversion 
		4. Single Responsability
		
		Fabrica (Factory) este unul dintre cele mai simple și mai utilizate șabloane de proiectare în .NET. Acesta aparține categoriei de șabloane de proiectare creational, care se concentrează pe modul în care obiectele sunt create.
		
		Factory Method este un șablon de proiectare care permite definirea unei metode într-o clasă de bază pentru a crea un obiect și permite subclaselor să modifice tipul de obiect care se creează. Cu alte cuvinte, clasele copil pot decide ce tip specific de obiect să creeze prin suprascrierea metodei factory din clasa de bază.
		
		Să luăm un exemplu pentru a înțelege mai bine. Presupuneți că aveți o aplicație care trebuie să proceseze diferite tipuri de documente: texte, imagini și fișiere audio. În loc să aveți o logică împrăștiată în întreaga aplicație pentru a crea obiectele corespunzătoare, puteți folosi Factory Method.

		Clasa de bază DocumentCreator ar putea avea o metodă factory numită CreateDocument(), iar clasele copil, cum ar fi TextDocumentCreator, ImageDocumentCreator și AudioDocumentCreator, ar suprascrie această metodă pentru a crea tipurile specifice de documente de care au nevoie.
		
		Iată un exemplu simplu de implementare a Factory Method Pattern în C# pentru crearea a trei tipuri de documente: text, imagine și fișier audio.
		
		using System;

		// Clasa de bază pentru documente
		public abstract class Document
		{
			public abstract void Open();
		}

		// Clasa pentru documente de tip text
		public class TextDocument : Document
		{
			public override void Open()
			{
				Console.WriteLine("Text Document opened.");
			}
		}

		// Clasa pentru documente de tip imagine
		public class ImageDocument : Document
		{
			public override void Open()
			{
				Console.WriteLine("Image Document opened.");
			}
		}

		// Clasa pentru documente de tip fișier audio
		public class AudioDocument : Document
		{
			public override void Open()
			{
				Console.WriteLine("Audio Document opened.");
			}
		}

		// Clasa de bază pentru creatorul de documente
		public abstract class DocumentCreator
		{
			public abstract Document CreateDocument();
		}

		// Creatorul de documente pentru documente de tip text
		public class TextDocumentCreator : DocumentCreator
		{
			public override Document CreateDocument()
			{
				return new TextDocument();
			}
		}

		// Creatorul de documente pentru documente de tip imagine
		public class ImageDocumentCreator : DocumentCreator
		{
			public override Document CreateDocument()
			{
				return new ImageDocument();
			}
		}

		// Creatorul de documente pentru documente de tip fișier audio
		public class AudioDocumentCreator : DocumentCreator
		{
			public override Document CreateDocument()
			{
				return new AudioDocument();
			}
		}

		class Program
		{
			static void Main(string[] args)
			{
				// Utilizare pentru documente de tip text
				DocumentCreator textCreator = new TextDocumentCreator();
				Document textDocument = textCreator.CreateDocument();
				textDocument.Open();

				// Utilizare pentru documente de tip imagine
				DocumentCreator imageCreator = new ImageDocumentCreator();
				Document imageDocument = imageCreator.CreateDocument();
				imageDocument.Open();

				// Utilizare pentru documente de tip fișier audio
				DocumentCreator audioCreator = new AudioDocumentCreator();
				Document audioDocument = audioCreator.CreateDocument();
				audioDocument.Open();
			}
		}
		
		Acest cod demonstrează modul în care puteți utiliza Factory Method Pattern pentru a crea și utiliza trei tipuri diferite de documente: text, imagine și fișier audio. Fiecare tip de document este reprezentat de o clasă separată (ex: TextDocument, ImageDocument, AudioDocument), iar fiecare creator de documente este responsabil pentru crearea unui tip specific de document (ex: TextDocumentCreator creează documente de tip text).



