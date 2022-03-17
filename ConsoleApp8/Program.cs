using System;
using System.IO;
class Program
{

    public static void Main()
	{

            // Print(Ilosc tablio, Ilosc elementow w tablicy, min. zakres w tablicy, max. zakres w tablicy, numer operacji, rodzaj operacji)
            // Rodzaj operacji: 1.Random 2.Sorted 3.Reversed 4.Almost sorted
            PrintSort Print1 = new PrintSort();

            //Proba mala 10-el
            //Console.Clear();
            FileStream geeks1 = new FileStream("raport.txt", FileMode.Create);
            //1.(random)
            Print1.Print(10, 10, 1, 10000, "1. Random", 1);
            //2.(sorted)
            Print1.Print(10, 10, 1, 10000, "2. Sorted", 2);
            //3.(reversed)
            Print1.Print(10, 10, 1, 10000, "3. Reversed", 3);
            //4.(almost sorted)
            Print1.Print(10, 10, 1, 10000, "4. Almost sorted", 4);
            //5.(few unique)
            Print1.Print(10, 10, 1, 10, "5. Few unique", 1);
            //Proba srednia 1000-el
            //6.(random)
            Print1.Print(10, 1000, 1, 10000, "6. Random", 1);
            //7.(sorted)
            Print1.Print(10, 1000, 1, 10000, "7. Sorted", 2);
            //8.(reversed)
            Print1.Print(10, 1000, 1, 10000, "8. Reversed", 3);
            //9.(almost sorted)
            Print1.Print(10, 1000, 1, 10000, "9. Almost sorted", 4);
            //10.(few unique)
            Print1.Print(10, 1000, 1, 10, "10. Few unique", 1);
            //Proba duza 100000-el
            //11.(random)
            Print1.Print(10, 100000, 1, 10000, "11. Random", 1);
            //12.(sorted)
            Print1.Print(10, 100000, 1, 10000, "12. Sorted", 2);
            //13.(reversed)
            Print1.Print(10, 100000, 1, 10000, "13. Reversed", 3);
            //14.(almost sorted)
            Print1.Print(10, 100000, 1, 10000, "14. Almost sorted", 4);
            //15.(few unique)
            Print1.Print(10, 100000, 1, 10, "15. Few unique", 1);


    }


}

