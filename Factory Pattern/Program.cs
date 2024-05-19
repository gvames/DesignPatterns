using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Factory_Pattern
{
    internal class Program
    {
        /*Presupuneți că aveți o aplicație care trebuie să proceseze diferite tipuri de documente: texte, imagini și fișiere audio.În loc să aveți o logică împrăștiată în întreaga aplicație 
         * pentru a crea obiectele corespunzătoare, puteți folosi Factory Method.
         * Clasa de bază DocumentCreator ar putea avea o metodă factory numită CreateDocument(), iar clasele copil, cum ar fi TextDocumentCreator, ImageDocumentCreator și AudioDocumentCreator, 
         * ar suprascrie această metodă pentru a crea tipurile specifice de documente de care au nevoie.
         * Iată un exemplu simplu de implementare a Factory Method Pattern în C# pentru crearea a trei tipuri de documente: text, imagine și fișier audio.
        
         * Acest cod demonstrează modul în care puteți utiliza Factory Method Pattern pentru a crea și utiliza trei tipuri diferite de documente: 
         * text, imagine și fișier audio. Fiecare tip de document este reprezentat de o clasă separată (ex: TextDocument, ImageDocument, AudioDocument),
         * iar fiecare creator de documente este responsabil pentru crearea unui tip specific de document (ex: TextDocumentCreator creează documente de tip text).
         */

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

            Console.ReadLine();
        }


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

}
}
