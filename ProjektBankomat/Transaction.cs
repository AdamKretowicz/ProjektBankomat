using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBankomat
{
    internal class Transaction
    {
        private Dictionary<int, int> banknoty;
        private Dictionary<int, int> banknotesBeforeOperations;

        public Transaction()
        {
            this.banknoty = (new Banknote()).Get("nominał, ilość").ToDictionary(arr => int.Parse(arr[0]), arr => int.Parse(arr[1]));
            this.banknotesBeforeOperations = (new Banknote()).Get("nominał, ilość").ToDictionary(arr => int.Parse(arr[0]), arr => int.Parse(arr[1]));
        }
        public void Withdraw(double kwota)
        {
            var kombinacje = ZnajdzKombinacjeWypłaty(kwota);

            if (kombinacje.Any())
            {
                var najlepszaKombinacja = kombinacje.First();
                WyprowadzBanknoty(najlepszaKombinacja);
                Console.WriteLine("Wypłacono kwotę:");
                foreach (var kvp in najlepszaKombinacja)
                {
                    Console.WriteLine($"{kvp.Value} x {kvp.Key} zł");
                }
            }
            else
            {
                Console.WriteLine("Brak możliwości wypłaty żądanej kwoty.");
            }

            AktualizujBanknoty();
        }

        public void Transfer(double kwota)
        {
            var dostepneNominaly = banknoty.Keys.OrderBy(x => x).ToList();
            List<Dictionary<int, int>> kombinacje = new List<Dictionary<int, int>>();
            var kombinacja = new Dictionary<int, int>();

            ZnajdzKombinacjeWplacaneRekurencyjnie(kwota, dostepneNominaly, kombinacje, kombinacja, 0);

            if (kombinacje.Any())
            {
                var najlepszaKombinacja = kombinacje.First();
                DodajBanknoty(najlepszaKombinacja);
                Console.WriteLine("Przelew zakończony pomyślnie:");
                foreach (var kvp in najlepszaKombinacja)
                {
                    Console.WriteLine($"{kvp.Value} x {kvp.Key} zł");
                }
            }
            else
            {
                Console.WriteLine("Nie można przelać żądanej kwoty.");
            }

            AktualizujBanknoty();
        }

        private void DodajBanknoty(Dictionary<int, int> kombinacja)
        {
            foreach (var kvp in kombinacja)
            {
                if (banknoty.ContainsKey(kvp.Key))
                {
                    banknoty[kvp.Key] += kvp.Value;
                }
                else
                {
                    banknoty[kvp.Key] = kvp.Value;
                }
            }
        }


        private void ZnajdzKombinacjeWplacaneRekurencyjnie(double kwota, List<int> dostepneNominaly, List<Dictionary<int, int>> kombinacje, Dictionary<int, int> kombinacja, int indeks)
        {
            if (kwota == 0)
            {
                kombinacje.Add(new Dictionary<int, int>(kombinacja));
                return;
            }

            if (kwota < 0 || indeks == dostepneNominaly.Count)
            {
                return;
            }

            var aktualnyNominal = dostepneNominaly[indeks];

            for (int i = 0; i <= (int)(kwota / aktualnyNominal); i++)
            {
                kombinacja[aktualnyNominal] = i;
                ZnajdzKombinacjeWplacaneRekurencyjnie(kwota - i * aktualnyNominal, dostepneNominaly, kombinacje, kombinacja, indeks + 1);
                kombinacja.Remove(aktualnyNominal);
            }
        }


        private List<Dictionary<int, int>> ZnajdzKombinacjeWypłaty(double kwota)
        {
            var dostepneNominaly = banknoty.Keys.OrderByDescending(x => x).ToList();
            List<Dictionary<int, int>> kombinacje = new List<Dictionary<int, int>>();
            var kombinacja = new Dictionary<int, int>();

            ZnajdzKombinacjeWypłatyRekurencyjnie(kwota, dostepneNominaly, kombinacje, kombinacja, 0);

            return kombinacje;
        }

        private void ZnajdzKombinacjeWypłatyRekurencyjnie(double kwota, List<int> dostepneNominaly, List<Dictionary<int, int>> kombinacje, Dictionary<int, int> kombinacja, int indeks)
        {
            if (kwota == 0)
            {
                kombinacje.Add(new Dictionary<int, int>(kombinacja));
                return;
            }

            if (kwota < 0 || indeks == dostepneNominaly.Count)
            {
                return;
            }

            var aktualnyNominal = dostepneNominaly[indeks];

            for (int i = banknoty[aktualnyNominal]; i >= 0; i--)
            {
                kombinacja[aktualnyNominal] = i;
                ZnajdzKombinacjeWypłatyRekurencyjnie(kwota - i * aktualnyNominal, dostepneNominaly, kombinacje, kombinacja, indeks + 1);
                kombinacja.Remove(aktualnyNominal);
            }
        }

        private void AktualizujBanknoty()
        {
            var diff = areEqual(banknoty, banknotesBeforeOperations);
            foreach (var i in diff)
            {
                (new Banknote()).Update(new Dictionary<string, string>(){
                    {"ilość", i.Value.ToString()}
                }, "nominał", i.Key);
            }
        }

        private void WyprowadzBanknoty(Dictionary<int, int> kombinacja)
        {
            foreach (var kvp in kombinacja)
            {
                banknoty[kvp.Key] -= kvp.Value;
            }
        }

        private Dictionary<int, int> areEqual(Dictionary<int, int> dict1, Dictionary<int, int> dict2)
        {
            Dictionary<int, int> differences = new Dictionary<int, int>();

            foreach (var kvp in dict1)
            {

                int key = kvp.Key;
                int value1 = kvp.Value;

                if (dict2.TryGetValue(key, out int value2))
                {
                    if (value1 != value2)
                    {
                        differences[key] = value1;
                    }
                }
            }

            return differences;
        }
    }
}
