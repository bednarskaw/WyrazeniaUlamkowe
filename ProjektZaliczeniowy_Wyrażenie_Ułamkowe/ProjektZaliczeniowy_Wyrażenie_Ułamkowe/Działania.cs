using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy_Wyrażenie_Ułamkowe
{
    class ArtNaUlamkach
    {
        public Ulamek Wykonaj_dzialania(List<Ulamek> lista_ulamkow, List<char> lista_znakow)
        {
            Ulamek wynik = lista_ulamkow[0];
            lista_ulamkow.RemoveAt(0);
            
            if (lista_znakow.Count == 0)
            {
                
                return Skr(wynik);
            }
            for(int i = 0; i < lista_znakow.Count; i++)
            {
                if (lista_znakow[i] == '+')
                {
                    wynik=pl(wynik, lista_ulamkow[i]);
                }
                else if (lista_znakow[i] == '-')
                {
                    wynik=min(wynik, lista_ulamkow[i]);
                }
                else if (lista_znakow[i] == '*')
                {
                    wynik=mnz(wynik, lista_ulamkow[i]);
                }
                else
                    wynik=div(wynik, lista_ulamkow[i]);
            }

            wynik=Skr(wynik);
            return wynik;
        }
        

        private int NWD(int k, int l)
        {
            int a = k; int b = l;
            while (a != b)
                if (a > b)
                {
                    a -= b;
                }
                else
                    b -= a;
            return a;

        }
        public Ulamek Skr(Ulamek a)
        {
            int d = NWD(a.licznik, a.mianownik);
            return new Ulamek(a.licznik / d, a.mianownik / d);
        }
        public Ulamek pl(Ulamek a, Ulamek b)
        {
            int L = a.licznik * b.mianownik + b.licznik * a.mianownik;
            int M = a.mianownik * b.mianownik;
            return new Ulamek(L, M);
        }
        public Ulamek min(Ulamek a, Ulamek b)
        {
            int L = a.licznik * b.mianownik - b.licznik * a.mianownik;
            int M = a.mianownik * b.mianownik;
            return new Ulamek(L, M);
        }
        public Ulamek mnz(Ulamek a, Ulamek b)
        {
            int L = a.licznik * b.licznik;
            int M = a.mianownik * b.mianownik;
            return new Ulamek(L, M);
        }
        public Ulamek div(Ulamek a, Ulamek b)
        {
            int L = a.licznik * b.mianownik;
            int M = a.mianownik * b.licznik;
            return new Ulamek(L, M);
        }

    }
}
