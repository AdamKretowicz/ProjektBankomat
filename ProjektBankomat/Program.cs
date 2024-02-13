using ProjektBankomat;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
      
        static void Main(string[] args)
        {
            //(new Transaction()).Withdraw(100);

            (new ATM()).Atm();

            //Dictionary<int, int> result = (new Banknote()).Get("nominał, ilość").ToDictionary(arr => int.Parse(arr[0]), arr => int.Parse(arr[1]));

            //Console.WriteLine(dictionary);

            //foreach (var banknote in banknotes)
            //{
            //    foreach (string value in banknote)
            //    {

            //    }
            //}


            //Login login = new Login();
            //login.Logging();
            ////Menu menu = new Menu();
            ////menu.MainMenu();
            //ATM atm = new ATM();
            //atm.Atm();
            //Translation translation = new Translation();
            //Console.WriteLine(translation.GetTranslation("pl", "deposit"));
            //Database database = new Database();
            //database.ConnectDatabase();
            ////Database database = new Database();
            ///


            //Bank bank = new Bank();
            //List<string[]> result = bank.Insert(new Dictionary<string, string>(){
            //    {"nazwa_banku", "Nowy Adas"},
            //    {"typ_banku", "Komercyjny45"},
            //});

            //Bank bank = new Bank();
            //bank.Update(new Dictionary<string, string>(){
            //    {"nazwa_banku", "Nowy Michas"},
            //    {"typ_banku", "Komercyjny40"},
            //}, 1039);

            //Banknote banknot = new Banknote();
            //Customer customer = new Customer();
            //Bank bank = new Bank();

            //Bank bank = new Bank();
            //List<string[]> result = bank.Get("nazwa_banku");

            //foreach (string[] rowdata in result)
            //{
            //    foreach (string value in rowdata)
            //    {
            //        Console.WriteLine(value);
            //    }
            //}

        }
    }
}