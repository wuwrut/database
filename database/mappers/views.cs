using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.models
{
    public class DostawyWToku
    {
        public int Nr_dostawy { get; set; }
        public string Nazwa { get; set; }
        public decimal Koszt_calkowity { get; set; }
        public string Nazwa_dostawcy { get; set; }
        public string Srodek_transportu { get; set; }
    }

    public class ProdukcjeWRealizacji
    {
        public int Numer_produkcyjny { get; set; }
        public string Nazwa_produktu { get; set; }
        public int Ilosc_produktu { get; set; }
        public string NazwaBroni { get; set; }
        public string Kaliber { get; set; }
    }

    public class ZamowieniaAmunicja
    {
        public int Numer_zamowienia { get; set; }
        public string Amunicja { get; set; }
        public int Ilosc_amunicji { get; set; }
    }

    public class ZamowieniaBron
    {
        public int Numer_zamowienia { get; set; }
        public string Bron { get; set; }
        public int Ilosc_broni { get; set; }
    }

    public class ZamowieniaDetaliczne
    {
        public int Numer_zamowienia { get; set; }
        public DateTime Data_dostawy { get; set; }
        public DateTime Data_zamowienia { get; set; }
        public string Zezwolenie_na_bron { get; set; }
        public string Uwagi { get; set; }
    }

    public class ZamowieniaHurtowe
    {
        public int Numer_zamowienia { get; set; }
        public DateTime Data_dostawy { get; set; }
        public DateTime Data_zamowienia { get; set; }
        public string Zezwolenie_na_handel { get; set; }
        public string Uwagi { get; set; }
    }

    public class ZamowieniaDoWykonania
    {
        public int Numer_zamowienia { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime Data_dostawy { get; set; }
        public string Uwagi { get; set; }
    }
}
