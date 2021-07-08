using System;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            //prima data disponibile
            DateTime dt = new DateTime(); 

            //Data per parametro
            DateTime dt2 = new DateTime(2021, 07, 05);

            //data di oggi con ore, minuti, secondi
            DateTime dt3 = DateTime.Now;

            //con .Date non mi visualizza ore minuti e secondi
            DateTime dt4 = dt3.Date;

            //posso recuperare anni, mesi e giorni
            int anno = dt3.Year;
            int mese = dt3.Month;
            int giorno = dt3.Day;
            
            //le date hanno anche la possibilità di aggiunta o di rimozione

            DateTime AggiuntaGiorni = dt3.AddDays(30);

            

            //le date sono ordinabili

            if (dt2.Date > dt4) //visual studio le riconosce
            { 

            }

            //posso anche convertire una stringa in una data

            DateTime dt5 = DateTime.Parse("06/07/2021");
            //sono accettati anche questi formati
            DateTime dt6 = DateTime.Parse("06-07-2021");
            DateTime dt7 = DateTime.Parse("06 07 2021");
            //Non accettate
            //DateTime dt8 = DateTime.Parse("20210706");
            //DateTime dt9 = DateTime.Parse("2021 07 06");

            Console.WriteLine("Inserisci una data antecedente alla data di inserimento"); //data di inserimento è il DateTime.Now.Date
            bool isDate = true;
            DateTime dataInserita;
            do
            {
                isDate = DateTime.TryParse(Console.ReadLine(), out dataInserita);
            } while (!isDate || dataInserita > DateTime.Now.Date); //questo è solo un confronto tra date quindi setta data di oggi alla mezzanotte

        }
    }
}
