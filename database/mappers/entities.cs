using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.models
{
    public class Amunicja
    {
        public int Numer_Pudelka { get; set; }
        public string Kaliber { get; set; }
        public int Ilosc_Amunicji { get; set; }
        public float Cena { get; set; }
        public Int64 PRODUKCJA_Numer_Produkcji { get; set; }
    }

    public class Bron
    {
        public int Numer_Seryjny { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public Int64 PRODUKCJA_Numer_Produkcyjny { get; set; }
        public int KATEGORIA_ID { get; set; }
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
        public string Zaswiadczenie_O_Niekaralnosci { get; set; }
    }

    public class Produkcja
    {
        public int Numer_Produkcyjny { get; set; }
        public string Nazwa_Produktu { get; set; }
        public int Ilosc_Produktu { get; set; }
    }

    public class Zamowienie
    {
        public Int64 Numer_Zamowienia { get; set; }
        public DateTime Data_Dostawy { get; set; }
        public DateTime Data_Zamowienia { get; set; }
        public string Uwagi { get; set; }
    }
}
