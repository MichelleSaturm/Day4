using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segreteria
{
    //Un appello ha:

    //un nome(materia)
    //una data di verbalizzazione
    //la tipologia(Scritto o orale)

    class LibrettoStudente
    {
        public string Materia { get; set; }
        public DateTime DataEsame { get; set; }
        public DateTime DataAppello { get; set; }
        public Tipologia TipoAppello { get; set; }

        public LibrettoStudente()
        {

        }

        public enum Tipologia
        {
            Scritto,
            Orale
        }
    }
}
