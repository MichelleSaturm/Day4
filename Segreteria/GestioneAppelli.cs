using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Segreteria.LibrettoStudente;

namespace Segreteria
{

    //L'utente può
    //vedere tutti gli esami
    //aggiungere un nuovo appello
    //eliminare un appello
    //filtrare gli appelli per tipo
    //Al termine delle operazioni vengono salvati gli appelli su file

    //!!!  Attenzione : la data dell'appello deve essere almeno
    //10 giorni dopo la data di inserimento dell'appello

    class GestioneAppelli
    {

        static List<LibrettoStudente> libretti = new List<LibrettoStudente>();

        static string path = @"C:\Users\princ\source\repos\Esercisi_Week2_Day2\appelli.txt";


        public static void Lettura()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string file = sr.ReadToEnd();
                    if (String.IsNullOrEmpty(file))
                    {
                        Console.WriteLine("Non sono presenti appelli.");
                    }
                    else
                    {
                        string[] contenutoFile = file.Split("\r\n");

                        for (int i = 1; i < (contenutoFile.Length - 1); i++)
                        {
                            LibrettoStudente ls = new LibrettoStudente();

                            string dati = contenutoFile[i];
                            string[] righe = dati.Split("\t\t");

                            ls.Materia = righe[0];
                            ls.DataAppello = DateTime.Parse(righe[1]);
                            ls.TipoAppello = (Tipologia)Enum.Parse(typeof(Tipologia), righe[2]);

                            libretti.Add(ls);
                        }
                    }



                }
            }
            else
            {
                Console.WriteLine("Non hai ancora registrato nessun esame.\nProcedi alla registrazione");
                RegistraEsami();
            }
        }
        public static void RegistraEsami()
        {
            do
            {
                LibrettoStudente ls = new LibrettoStudente();
                Console.WriteLine("Inserisci la Materia");
                ls.Materia = Console.ReadLine();

                Console.WriteLine("Inserisci la Data nella quale hai dato l'Esame");
                ls.DataEsame = DataEsame();

                Console.WriteLine("Inserisci il tipologia");
                ls.TipoAppello = InserisciTipologia();

                libretti.Add(ls);

                Console.WriteLine("Vuoi registrare un altro esame? Premi 'n' per uscire, altrimenti un qualsiasi altro tasto");
            } while (!(Console.ReadKey().KeyChar == 'n'));


        }

        public static Tipologia InserisciTipologia()
        {
            Console.WriteLine($"Premi {(int)Tipologia.Orale} per un Esame {Tipologia.Orale}");
            Console.WriteLine($"Premi {(int)Tipologia.Scritto} per un Esame {Tipologia.Scritto}");

            bool isInt;
            int tipoEsame;
            do
            {
                isInt = int.TryParse(Console.ReadLine(), out tipoEsame);
            } while (!isInt || tipoEsame < 0 || tipoEsame > 1);
            return (Tipologia)tipoEsame;
        }

        public static DateTime DataEsame()
        {
            bool isDate = true;
            DateTime dataInserita;
            do
            {
                isDate = DateTime.TryParse(Console.ReadLine(), out dataInserita);
            } while (!isDate || dataInserita < DateTime.Now.Date);
            return dataInserita;
        }

        public static void AggiungiNuovoAppello()
        {
            List<LibrettoStudente> nuovoAppello = new List<LibrettoStudente>();
            Console.WriteLine("Stai aggiungendo un nuovo appello.");
            Console.WriteLine("Cerca la materia");
            string materia = Console.ReadLine();
            foreach (LibrettoStudente ls in libretti)
            {
                if (ls.Materia == materia)
                {
                    nuovoAppello.Add(ls);
                }
            }
            Console.WriteLine($"");


            Console.WriteLine("Inserisci la data del nuovo appello");


        }


        public static void EliminaAppello()
        {

        }

        public static void MostraAppelli()
        {

        }

        public static void FiltraPerTipo()
        {

        }

        public static void StampaSuFile()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Materia\t Data\t Tipo");
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (LibrettoStudente ls in libretti)
                {
                    sw.WriteLine($"{ls.Materia}\t\t{ls.DataAppello}\t\t {ls.TipoAppello}");
                }
            }
        }
    }
}

