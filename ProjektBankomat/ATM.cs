using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBankomat
{
    internal class ATM
    {
        public void Atm() 
        {
            Login logging = new Login();
            bool isLogged = logging.Logging();
            if(isLogged)
            {
                Menu menu = new Menu();
                menu.MainMenu();
            }

        }
    }
}
