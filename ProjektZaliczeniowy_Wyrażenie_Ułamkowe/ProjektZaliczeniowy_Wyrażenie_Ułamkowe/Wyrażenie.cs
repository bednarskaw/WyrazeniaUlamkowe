using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy_Wyrażenie_Ułamkowe
{
    
    class Wyrażenie
    {

        public List<Ulamek> lista_ulamkow = new List<Ulamek>();
        public List<char> lista_znakow = new List<char>();
        public List<Tuple<int,int>> nawias = new List<Tuple<int,int>>();
        public List<int> pozycje_kreski = new List<int>();
        public List<char> lista_pierwotna= new List<char>();

        public Ulamek wynik;
      
        public char wyrazenie;
        public int licznik;
        Stack<int> myStack = new Stack<int>();
        public Wyrażenie()
        {
            licznik = 0;
        }
        public void Stworz_wyrazenie(List<char> lista)
        {
            Ulamek ulamek = new Ulamek();
            licznik++;
            List<char> arr = new List<char>();
            arr.AddRange(lista);
            //arr.Reverse();
           

            var idx = Array.FindIndex(lista.ToArray(), Kreska_ulamkowa); //sprawdzam czy jest kreska
            if (licznik == 1)
                lista_pierwotna = lista;


            if (idx != -1)
            {
                if (licznik == 1)
                {
                    for(int i=0; i<lista.Count;i++)
                    {
                        if (lista[i] == '(')
                        {

                            
                            myStack.Push(i);
                            arr.Remove(lista[i]);


                        }
                        else if (lista[i] == ')')
                        {
                            //myStack.Pop();

                            //int tmp = Array.FindIndex(arr.ToArray(), Znajdz_domkniety);
                            Tuple<int, int> t = new Tuple<int, int>(myStack.Peek(), i);
                            myStack.Pop();
                            nawias.Add(t);
                            arr.Remove(lista[i]);

                        }
                        else if (lista[i] == '|')
                        {
                            
                            pozycje_kreski.Add(i);


                        }
                    }
                }
                if (wyrazenie == arr[0])
                {
                    arr.RemoveAt(0);
                }

                 var idx3 = Array.FindIndex(arr.ToArray(), Kreska_ulamkowa);
                char[] tablica_z_licznikiem = new char[idx3];
                Array.Copy(arr.ToArray(), arr.ToArray().GetLowerBound(0), tablica_z_licznikiem, tablica_z_licznikiem.GetLowerBound(0), idx3);
                arr.RemoveRange(0, idx3 + 1);

              
                ulamek.licznik = ulamek.Zbuduj(tablica_z_licznikiem);
              
                
                var idx2 = Array.FindIndex(lista_pierwotna.ToArray(), Wyrazenia_rozdzielajace);
                if (nawias.Count != 0)
                {
                    while (idx2 < nawias[licznik - 1].Item2 && nawias[licznik - 1].Item2!=lista_pierwotna.Count-1)
                    { 
                            idx2 = Array.FindIndex(lista_pierwotna.ToArray(), idx2 + 1, Wyrazenia_rozdzielajace); //szukamy wyrażenia za nawiasem domkniętym                            
                    }
                    if(nawias[licznik - 1].Item2 == lista_pierwotna.Count - 1)
                    {
                        idx2 = -1;
                    }
                }
                    
                    if (idx2 != -1)
                    {

                        lista_znakow.Add(wyrazenie);
                        char[] tablica_z_mianownikiem;
                        idx2 = Array.FindIndex(arr.ToArray(), Znajdz_wyrazenie);
                    if (idx2 == -1)
                    {
                        idx2 = arr.Count;
                        lista_znakow.RemoveAt(0);

                    }
                    tablica_z_mianownikiem = new char[idx2];
                    Array.Copy(arr.ToArray(), arr.ToArray().GetLowerBound(0), tablica_z_mianownikiem, tablica_z_mianownikiem.GetLowerBound(0), idx2);
                        arr.RemoveRange(0, idx2);


                        ulamek.mianownik = ulamek.Zbuduj(tablica_z_mianownikiem);
                    
                       
                        
                    }
                    else
                    {
                        char[] tablica_z_mianownikiem2 = new char[lista.Count];
                        Array.Copy(arr.ToArray(), arr.ToArray().GetLowerBound(0), tablica_z_mianownikiem2, tablica_z_mianownikiem2.GetLowerBound(0), arr.Count);
                        arr.Clear();
                        ulamek.mianownik = ulamek.Zbuduj(tablica_z_mianownikiem2);
                    }

                
             


                if (ulamek.licznik != 0 && ulamek.mianownik != 0)
                {
                    lista_ulamkow.Add(ulamek);
                }
                else
                    Console.WriteLine("Pominięto nieprawidłowy ułamek nr: "+licznik);
                if (arr.Count > 0)
                {
                    Stworz_wyrazenie(arr);

                }
                else
                {
                    ArtNaUlamkach dzialania = new ArtNaUlamkach();
                    wynik = dzialania.Wykonaj_dzialania(lista_ulamkow, lista_znakow);
                }
            }
            else
            {
                Console.WriteLine("Niepoprawne wyrażenie ułamkowe");
                Console.ReadKey();
                Environment.Exit(0);
            }
           
            Console.WriteLine();

        }
        public void Wyswietl_wynik()
        {
            
                Console.WriteLine("{0,24}", wynik.licznik);
                Console.WriteLine("{0,29}", "--------------");
                Console.WriteLine("{0,24}", wynik.mianownik);


        }


        private bool Wyrazenia_rozdzielajace(char c)
        {
            if (c == '-' || c == '+' || c == '/' || c == '*' || c == '|')
            {
                wyrazenie = c;
                return true;


            }

            else
            {
                return false;
            }
        }
        private bool Kreska_ulamkowa(char c)
        {
            if ( c == '|')
            {
                
                return true;
            }

            else
            {
                return false;
            }
        }
        private bool Znajdz_wyrazenie(char c)
        {
            if (c == wyrazenie)
            {
                
                return true;
            }

            else
            {
                return false;
            }
        }

       


    }
   
}
