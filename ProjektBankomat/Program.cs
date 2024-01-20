using ProjektBankomat;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Banknote banknot = new Banknote();
            //Model model = new Model();
            List<string[]> result = banknot.Get();

            foreach (string[] rowData in result)
            {
                foreach (string value in rowData)
                {
                    Console.WriteLine(value);
                    //Console.Write(value + "\t");
                }
                //Console.WriteLine();
            }
           

            


        }
    }
}