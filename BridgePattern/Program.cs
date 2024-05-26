using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Vezi: Visitor Pattern & Strategy Pattern
             * 
             * Scopul acestui pattern este decuplarea abstractiilor de implementarea lor,
             * astfel ele pot varia independet.
             * 
             * Key words: cartesian product
             * 
             *  Abstraction ->     (has a)     -> IImplementor
             *       ^                             ^
             *      / \                           / \
             *       |                             |
             * ConcreteAbstractions         ConcreteImplementors
             *  (are Abstraction)             (are IImplementor)
             * 
             * 
             * Ex:
             *      +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+          (has a)          +----------------+
             *      |    View        |-------------------------->| IMediaResource |
             *      +________________+                           +________________+
             *      | ctor(Resource) |                           | snippet()      |
             *      |                |                           | image()        |
             *      |                |                           | title()        |  
             *      | string Show()  |                           | url()          |
             *      +________________+                           +________________+
             *            /\                                            /\                               
             *            ||                                            ||
             *            ||                                            ||
             *      +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+                   +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+
             *      | Long Form             |-+                 | Artist Resource |-+
             *      |                       | |-+               |                 | |-+  
             *      | override string Show()| | |               | snippet()       | | |  
             *      |                       | | |               | image()         | | |
             *      |                       | | |               | title()         | | |
             *      |                       | | |               | url()           | | |
             *      +_______________________+ | |               |                 | | |
             *       |Short From              | |               +_________________+ | |
             *       +________________________+ |                | Movie Resource   | |  
             *        |Thumbnail Form           |                +__________________+ |
             *        +_________________________+                 | Book Resource     |
             *                                                    +___________________+
             *          
             */
        }
    }


    abstract class View
    {
        internal IResource _resource;
        public View(IResource resource)
        {
            _resource = resource;
        }

        public abstract string Show();
    }
    public interface IResource
    {
        string Snippet();
        string Image();
        string Title();
        string Url();
    }

    class LongForm : View
    {
        public LongForm(IResource resource) : base(resource)
        {
        }

        public override string Show()
        {
            //....;
            return _resource.Snippet();
        }
    }

    class ArtistResource : IResource
    {
        Artist _artist;

        public ArtistResource(Artist artist)
        {
            _artist = artist;
        }
        public string Image()
        {
            return "ImageOfArtist";
        }

        public string Snippet()
        {
            return "SnippetOfArtist";
        }

        public string Title()
        {
            return _artist.FName + " " + _artist.LName;
        }

        public string Url()
        {
            return "UrlOfArtist";
        }
    }

    public class Artist
    {
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
