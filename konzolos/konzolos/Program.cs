using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konzolos
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Statisztika.beolvas();
                Statisztika.kiir();

                Console.WriteLine("\n******************** SZÁMOLÁSI FELADATRÉSZ ********************");

                Statisztika.oldalSzam();
                Statisztika.regi();
                Statisztika.leghosszabb();
                Statisztika.legtobb();
                //Statisztika.megadas("Bekért könyv");




            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt: {ex.Message}");
                Console.ReadKey();
            }
            Console.ReadLine();
            Console.WriteLine("\n*** Program vége! ***");
            Console.ReadKey();
        }
    }
}
