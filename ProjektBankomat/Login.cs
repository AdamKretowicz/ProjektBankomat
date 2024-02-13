using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBankomat
{
    internal class Login
    {
        public bool Logging() 
        {
            Console.WriteLine("Podaj nr karty");
            string nrKarty = Console.ReadLine();
            bool successful = false;
            List<string[]> customers = new List<string[]>();
            string givenPin = null;

            //nr_karty do testow
            //3712904567890123

            int i = 3;
            while (i > 0)
            {
                Console.WriteLine("Podaj PIN");
                givenPin = Console.ReadLine();

                customers = (new Customer()).Get("PIN", "nr_karty", nrKarty);

                foreach (string[] rowdata in customers)
                {
                    foreach (string value in rowdata)
                    {
                        successful = givenPin == value;
                    }
                }

                if (successful)
                {
                    Console.Clear();
                    return true;

                }
                else
                {
                    if (i - 1 == 0)
                    {
                        Console.WriteLine("Wykorzystano wszystkie próby, odmowa dostępu");
                    }
                    else
                    {
                        Console.WriteLine("Błędny PIN, spróbuj jeszcze raz, pozostało prób: " + (i - 1));
                    }
                }
                i--;
            }
            return false;
        }
    }
}
