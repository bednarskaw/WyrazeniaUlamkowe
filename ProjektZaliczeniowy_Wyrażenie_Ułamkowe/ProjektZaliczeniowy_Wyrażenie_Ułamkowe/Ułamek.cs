using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy_Wyrażenie_Ułamkowe
{
    class Ulamek
    {
        public int licznik;
        public int mianownik;
       
        public Ulamek() { }
        public Ulamek(int l, int m)
        {
            licznik = l;
            mianownik = m;
        }
        public int Zbuduj(char[] arr, int idx_o=-1, int idx_z=-1)
        {
            string tekst = "";
            char dzialanie = '+';
            int wynik2 = 0;
            int result = 0;
          
            bool poprzedni_jest_tekstem = false;
        
            if (idx_z == -1 || idx_o == -1)
            {
                idx_o = 0;
                idx_z = arr.Length+1;
                

            }
           
            for (int i = idx_o; i < idx_z-1; i++)
            {
                
                if (!Char.IsDigit(arr[i]))
                {
                    
                    
                    if (arr[i] != '-' && arr[i] != '+' && arr[i] != '*' && arr[i] != '/'&&dzialanie=='+')
                    {
                        result += System.Convert.ToInt16(arr[i]) + wynik2;
                        wynik2 = 0;
                        poprzedni_jest_tekstem = true;

                        if (tekst.Length > 0)
                        {
                            result += Int32.Parse(tekst);
                            tekst = "";
                        }
                    }
                    else if (arr[i] != '-' && arr[i] != '+' && arr[i] != '*' && arr[i] != '/' && dzialanie == '-')
                    {
                        result -= System.Convert.ToInt16(arr[i]) + wynik2;
                        wynik2 = 0;
                        poprzedni_jest_tekstem = true;

                        if (tekst.Length > 0)
                        {
                            result += Int32.Parse(tekst);
                            tekst = "";
                        }
                    }
                    else if (arr[i] != '-' && arr[i] != '+' && arr[i] != '*' && arr[i] != '/' && dzialanie == '*')
                    {
                       
                        wynik2 += System.Convert.ToInt16(arr[i]);
                        if (i == arr.Length - 1 || Sprawdz(arr[i+1]))
                        {
                            if (result != 0)
                            {
                                result *= wynik2;
                                wynik2 = 0;
                            }
                            else if (tekst != "")
                                result = Int32.Parse(tekst) * wynik2;
                            
                        }
                        
                      
                        poprzedni_jest_tekstem = true;

                       
                    }
                    else if (arr[i] != '-' && arr[i] != '+' && arr[i] != '*' && arr[i] != '/' && dzialanie == '/')
                    {
                        
                        wynik2 += System.Convert.ToInt16(arr[i]);
                        if (i == arr.Length - 1 || Sprawdz(arr[i + 1]))
                        {
                            if (result != 0)
                            {
                                result /= wynik2;
                                wynik2 = 0;
                            }
                            else
                                result = Int32.Parse(tekst) / wynik2;
                        }
                    }
                    else
                    {
                        dzialanie = arr[i];
                    }
                }
                else if (poprzedni_jest_tekstem == true)
                {
                    if (dzialanie == '+')
                    {
                        wynik2 += arr[i] - '0';
                        poprzedni_jest_tekstem = false;
                        if (i == arr.Length - 1)
                        {
                            result += wynik2;
                            wynik2 = 0;
                        }
                    }
                    else if (dzialanie == '-')
                    {
                        wynik2 -= arr[i] - '0';
                        poprzedni_jest_tekstem = false;
                        if (i == arr.Length - 1 || Sprawdz(arr[i+1]))
                        {
                            result += wynik2;
                            wynik2 = 0;
                        }
                    }
                    else if (dzialanie == '*')
                    {
                        if (wynik2 != 0)
                        {
                            wynik2 *= arr[i] - '0';
                        }
                        else
                        {
                            if (i == arr.Length - 1 || Sprawdz(arr[i+1]))
                            {
                                result *= arr[i] - '0';
                            }
                            else
                            {
                                tekst += arr[i] - '0';
                            }
                        }
                        poprzedni_jest_tekstem = false;
                      
                    }
                    else if (dzialanie == '/')
                    {
                        if (wynik2 != 0)
                        {
                            wynik2 /= arr[i] - '0';
                        }
                        else
                        {
                            if (i == arr.Length - 1 || Sprawdz(arr[i + 1]))
                            {
                                result /= arr[i] - '0';
                            }
                            else
                            {
                                tekst += arr[i] - '0';
                            }
                        }
                        poprzedni_jest_tekstem = false;
                      

                    }
                }
                else 
                {
                    if (dzialanie == '+')
                    {
                        if (wynik2 != 0) //w wynik2 trzymam liczbę z poprzedniego np 5 z t56
                        {
                            tekst += wynik2;
                            wynik2 = 0;
                        }
                        tekst += arr[i]; //dodaje do trzymanej cyfry i tworzę liczbę
                        if (i == arr.Length - 1 || Sprawdz(arr[i + 1]))
                        {
                            result += Int32.Parse(tekst); //w result będzie t i dodaje 56
                            tekst = "";
                        }
                    }
                    else if (dzialanie == '-')
                    {
                        if (wynik2 != 0)
                        {
                            tekst += wynik2;
                            wynik2 = 0;
                        }
                        if (i == 0 || !Sprawdz(arr[i - 1])) //sprawdza czy dalej będzie działanie czy będziemy budować wyrażenie 
                        {
                            tekst += arr[i];
                        }
                        if (i == arr.Length - 1 || Sprawdz(arr[i + 1]))
                        {
                            if (result != 0 && tekst != "")
                                result -= Int32.Parse(tekst);
                            else
                            {
                                if (tekst != "")
                                {
                                    result += Int32.Parse(tekst);
                                }
                                result -= arr[i] - '0';
                            }
                            tekst = "";
                        }
                    }
                    else if (dzialanie == '*')
                    {
                        if (wynik2 != 0)
                        {
                            tekst += wynik2;
                            wynik2 = 0;
                        }
                        if (i == 0 || !Sprawdz(arr[i - 1]))
                        {
                            tekst += arr[i];
                        }
                        if (i == arr.Length - 1 || Sprawdz(arr[i + 1]))
                        {
                            if (result != 0 && tekst!="")
                                result *= Int32.Parse(tekst);
                            else
                            {
                                if (tekst != "")
                                {
                                    result += Int32.Parse(tekst);
                                }
                                result *= arr[i]-'0';
                            }
                            tekst = "";
                        }
                    }
                    else if (dzialanie == '/')
                    {
                        if (wynik2 != 0)
                        {
                            tekst += wynik2;
                            wynik2 = 0;
                        }
                        if (i == 0 || !Sprawdz(arr[i - 1]))
                        {
                            tekst += arr[i];
                        }
                        else if (i == arr.Length - 1 || Sprawdz(arr[i + 1]))
                        {
                            if (result != 0 && tekst !="")
                                result /= Int32.Parse(tekst);
                            else
                            {
                                if (tekst != "")
                                {
                                    result += Int32.Parse(tekst);
                                }
                                result /= arr[i]-'0';
                            }
                            tekst = "";
                        }
                      
                    }

                }

            }
           
            return result;
        }
        private bool Sprawdz(char c)
        {
            if (c == '-' || c == '+' || c == '/' || c == '*' || c == '|')
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
