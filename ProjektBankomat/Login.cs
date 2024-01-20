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
            int i = 3;
            while (i > 0)
            {

                Console.WriteLine("Podaj PIN");
                string correctPin = "1234";
                string givenPin = Console.ReadLine();
                if (givenPin == correctPin)
                {
                    Console.WriteLine("Poprawny PIN");
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
