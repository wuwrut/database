using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.models
{
    public class Amunicja
    {
        public int Numer_pudelka { get; set; }
        public string Kaliber { get; set; }
        public int Ilosc_amunicji { get; set; }
    }

    public class Bron
    {
        public int Numer_seryjny { get; set; }
        public string Nazwa { get; set; }
    }

    public class Material
    {
        public Int64 ID { get; set; }
        public string Nazwa { get; set; }
        public int Ilosc { get; set; }
    }

    public class Pracownik
    {
        public Int64 PESEL { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Zaswiadczenie_o_niekaralnosci { get; set; }
    }

    public class Produkcja
    {
        public int Numer_produkcyjny { get; set; }
        public string Nazwa_produktu { get; set; }
        public int Ilosc_produktu { get; set; }
    }
}
