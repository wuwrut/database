﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.models
{
    public class Bron
    {
        public Int64 Numer_Seryjny { get; set; }
        public string Nazwa { get; set; }
        public Decimal Cena { get; set; }
        public Int64 PRODUKCJA_Numer_Produkcyjny { get; set; }
        public int KATEGORIA_ID { get; set; }
    }

    public class Amunicja
    {
        public Int64 Numer_Pudelka { get; set; }
        public string Kaliber { get; set; }
        public int Ilosc_Amunicji { get; set; }
        public float Cena { get; set; }
        public Int64 PRODUKCJA_Numer_Produkcji { get; set; }
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
        public Int64 Numer_Produkcyjny { get; set; }
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

    public class Hurtowe
    {
        public Int64 Numer_Zamowienia { get; set; }
        public string Zezwolenie_Na_Handel { get; set; }
    }

    public class Detaliczne
    {
        public Int64 Numer_Zamowienia { get; set; }
        public string Zezwolenie_Na_Bron { get; set; }
    }

    public class Dostawa
    {
        public Int64 Nr_Dostawy { get; set; }
        public string Nazwa_dostawcy { get; set; }
        public Decimal Koszt_Calkowity { get; set; }
    }

    public class Kategoria
    {
        public Int64 ID { get; set; }
        public string Nazwa { get; set; }
    }

    public class User_Bron
    {
        public string Nazwa_Broni { get; set; }
        public Decimal Cena { get; set; }
        public string Kategoria { get; set; }
    }

    public class User_Ammo
    {
        public string Nazwa { get; set; }
        public Decimal Cena { get; set; }
        public int Sztuk_w_pudelku { get; set; }
    }
}
