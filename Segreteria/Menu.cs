using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segreteria
{
    class Menu
    {

        public static void Start()
        {
            GestioneAppelli.Lettura();
            
            bool continuare = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1 - Aggiungi un nuovo appello");
                Console.WriteLine("2 - Elimina appello");
                Console.WriteLine("3 - Vedi Elenco");
                Console.WriteLine("4 - Filtra i per Tipo ");
                Console.WriteLine("0 - Exit");

                Console.WriteLine();
                Console.Write("Inserisci la tua scelta: ");


                int choice;
                bool isInt;
                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out choice);
                } while (!isInt);

                switch (choice)
                {
                    case 1:
                        GestioneAppelli.AggiungiNuovoAppello();
                        break;
                    case 2:
                        GestioneAppelli.EliminaAppello();
                        break;
                    case 3:
                        GestioneAppelli.MostraAppelli();
                        break;
                    case 4:
                        GestioneAppelli.FiltraPerTipo();
                        break;
                    case 0:
                        GestioneAppelli.StampaSuFile();
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("La scelta è sbagliata. Riprova.");
                        break;
                }
            } while (continuare);

        }

    }
}
