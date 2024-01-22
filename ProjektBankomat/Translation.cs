using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBankomat
{
    internal class Translation
    {
        Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "pl", new Dictionary<string, string>
                {
                    { "withdraw", "wypłata" },
                    { "deposit", "wpłata" },
                    { "balance", "stan konta" },
                    { "change language", "zmień język" },
                    { "thank you", "dziękujemy" },
                    { "", "błędny wybór" }


                }
            },
            {
                "en", new Dictionary<string, string>
                {
                    { "withdraw", "withdraw" },
                }
            }
        };
        public string GetTranslation(string langcode, string key) 
        {

            return this.translations[langcode][key];
        }
    }
}
