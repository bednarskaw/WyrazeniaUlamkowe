using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy_Wyrażenie_Ułamkowe
{
    class Program
    {
        static void Main(string[] args)
        {


            string arr = "(2+1|t+1)*(t|2)"; 
            Console.WriteLine("Dla wyrażenia: "+arr);
            Wyrażenie w = new Wyrażenie();
            w.Stworz_wyrazenie( arr.ToList());
            w.Wyswietl_wynik();
            Console.WriteLine();

            string arr2 = "(t|1)+(t|1)+(t|1)";
            Console.WriteLine("Dla wyrażenia: " + arr2);
            Wyrażenie w2 = new Wyrażenie();
            w2.Stworz_wyrazenie(arr2.ToList());
            w2.Wyswietl_wynik();
            Console.WriteLine();

            string arr3 = "(ttt|5)/(2|1)-(5|3)";
            Console.WriteLine("Dla wyrażenia: " + arr3);
            Wyrażenie w3 = new Wyrażenie();
            w3.Stworz_wyrazenie(arr3.ToList());
            w3.Wyswietl_wynik();
            Console.WriteLine();

            string arr4 = "t5-5*t|5";
            Console.WriteLine("Dla wyrażenia: " + arr4);
            Wyrażenie w4 = new Wyrażenie();
            w4.Stworz_wyrazenie(arr4.ToList());
            w4.Wyswietl_wynik();
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}
