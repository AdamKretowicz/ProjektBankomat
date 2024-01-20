using System.Text;

namespace ProjektBankomat
{
    internal class Menu
    {
        public void MainMenu() {
            Console.WriteLine("1. Wypłata");
            Console.WriteLine("2. Wpłata");
            Console.WriteLine("3. Stan konta");
            Console.WriteLine("4. Zmień język");
            Console.WriteLine("0. Zakończ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                    Console.WriteLine("Dziekujemy");
                    break;
                case "1":
                    TransactionMenu(true);
                break;

                case "2":
                    TransactionMenu();
                break;

                case "3":
                    BalanceMenu();
                break;

                case "4":
                    Console.Clear();
                    ChangeLanguageMenu();

                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Błędny wybór");
                    MainMenu();
                    break;

            }
        }
        public void BalanceMenu()
        {
            Console.Clear();
            Console.WriteLine("Twój stan konta to: 5000 ");
            Console.WriteLine("0. Powrót ");
            if (Console.ReadLine() == "0")
            {
                MainMenu();
            }

        }
        //public void BackMenu()
        //{
        //    Console.WriteLine("0 - Powrót");
        //    if (Console.ReadLine() == "0") 
        //    {
        //        MainMenu();
        //    }
            
        //}
        public void TransactionMenu(bool withdraw = false)
        {
            Console.Clear();
            if (withdraw)
            {
                Console.WriteLine("Jaką kwotę chcesz wypłacić?");
            }
            else
            {
                Console.WriteLine("Jaką kwotę chcesz wpłacić?");
            }
            Console.WriteLine("1. 50zł");
            Console.WriteLine("2. 100zł");
            Console.WriteLine("3. 200zł");
            Console.WriteLine("4. 500zł");
            Console.WriteLine("5. Twoja kwota");
            Console.WriteLine("0. Powrót");
            int amount = 0;
            switch(Console.ReadLine())
            {
                case "0":
                    MainMenu();
                break;
                case "1":
                    amount = 50;
                break;

                case "2":
                    amount = 100;
                    break;

                case "3":
                    amount = 200;
                    break;

                case "4":
                    amount = 500;
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("Wpisz kwotę, którą chcesz wypłacić ");
                    try
                    {
                        amount = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Niepoprawne znaki");

                        TransactionMenu(withdraw);
                    }
                    
                    break;
            }
            Confirm(amount);
        }
        public void ChangeLanguageMenu()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("1. Polski");
            Console.WriteLine("2. Українська");
            Console.WriteLine("3. English");
            Console.WriteLine("4. Deutsch");
            Console.WriteLine("5. Français");
            Console.WriteLine("0. Powrót");
            if (Console.ReadLine() == "0")
            {
                MainMenu();
            }


        }
        public void Confirm(int amount)
        {
            Console.Clear();
            Console.WriteLine("Czy na pewno chcesz wypłacić " + amount + " zł");
            Console.WriteLine("1. Tak");
            Console.WriteLine("2. Nie");
            if(Console.ReadLine() != "1")
            {
                Environment.Exit(0);
            }
            Console.Clear();
            Console.WriteLine("Wypłacono " + amount + " zł");
        }

    }
}
