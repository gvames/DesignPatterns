using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Acest design converteste interfata unei clase intr-o alta interfata pe care clientii o asteapta.
                * Adaptorul pemite claselor sa functioeneze impreuna, clase care nu ar fi putut face asta din cauza 
                * din pricina incompatibilitatii.
                * 
                * 
                * 
                * Exista 4 patternuri care sunt foarte usor de confundat:
                * 1.Adapter (Wrapper) - Este despre a face 2 interfete incompatibile sa devina compatibile;
                * 
                * 2.Facade - Este modliatatea prin care o intercatiune complicata cu obiecte complicate poate fi extrasa in 
                * in interfete numite fatade.
                *   Ascunde logica complexa din spate.
                * 
                * 3.Proxy - Este o metoda prin care este pozitionat un proxy intre apelant si ceea ce este apelat.
                *   In acest fel, apelul se faace catre Proxy care la randul sau apeleaza obiectul final.
                *   Astfel Proxy-ul intercepteaza apelurile si controleaza accesul la obiectul de baza.
                *   Motivele ar putea fi:
                *       1. Security;
                *       2. Caching;
                *       3. ...
                * 
                * 4.Decorator - Adauga nou comportament unui obiect fara sa modifice comportamentul obiectului curent;
                *           
                * 
                * 
                * 
                *      +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+       (has a)        +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+
                *      |    Client      |--------------------->| ITarget        |
                *      +________________+                      +________________+
                *      |                |                      | request()      |
                *      |                |                      |                |
                *      |                |                      |                |  
                *      |                |                      |                |
                *      +________________+                      +________________+
                *                                                      ^                               
                *                                                     / \
                *                                                     ‾|‾ 
                *                                                      |
                *                                              +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+       +‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾+
                *                                              |     Adapter     |       |   Adaptee       |
                *                                              |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾|       |‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾|
                *                                              | request()       | has a |specificRequest()|
                *                                              |                 |------>|                 |
                *                                              |                 |       |                 |
                *                                              |                 |       |                 |
                *                                              |                 |       |                 |
                *                                              +_________________+       +_________________+
                */
        }
    }
}
