// C# program for implementation of Insertion Sort
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
public class PrintSort
{

    //PrintArray
    static void printArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }

    //InsertSort
    void sort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }

    //Mergesort
    void merge2(int[] arr, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;

        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;

        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];

        i = 0;
        j = 0;

        int k = l;
        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    void sort2(int[] arr2, int l, int r)
    {
        if (l < r)
        {
            int m = l + (r - l) / 2;

            sort2(arr2, l, m);
            sort2(arr2, m + 1, r);

            merge2(arr2, l, m, r);
        }
    }

    //QuicksortClassical

    static void swap3(int[] arr3, int i, int j)
    {
        int temp = arr3[i];
        arr3[i] = arr3[j];
        arr3[j] = temp;
    }

    static int partition3(int[] arr3, int low, int high)
    {

        int pivot = arr3[high];

        int i = (low - 1);

        for (int j = low; j <= high - 1; j++)
        {

            if (arr3[j] < pivot)
            {
                i++;
                swap3(arr3, i, j);
            }
        }
        swap3(arr3, i + 1, high);
        return (i + 1);
    }

    static void quickSort3(int[] arr3, int low, int high)
    {
        if (low < high)
        {
            int pi = partition3(arr3, low, high);
            quickSort3(arr3, low, pi - 1);
            quickSort3(arr3, pi + 1, high);
        }
    }
    static double standardDeviation(IEnumerable<double> sequence)
    {
        double result = 0;

        if (sequence.Any())
        {
            double average = sequence.Average();
            double sum = sequence.Sum(d => Math.Pow(d - average, 2));
            result = Math.Sqrt((sum) / sequence.Count());
        }
        return result;
    }

    static double averageTime(double[] x, int xcount)
    {
        double time = 0;
        for(int i = 0; i<xcount;i++)
        {
            time = time + x[i];
        }
        time = time / xcount;
        return time;
    }

    public int[] ChooseArray(int[] arr,int x, int n, int minz, int maxz) 
    {
        
        if (x == 1) { arr = Generators.GenerateRandom(n, minz, maxz); }
        else if (x == 2) { arr = Generators.GenerateSorted(n, minz, maxz); }
        else if (x == 3) { arr = Generators.GenerateReversed(n, minz, maxz); }
        else if (x == 4) { arr = Generators.GenerateAlmostSorted(n, minz, maxz); }
        else
        {
            Console.WriteLine("Wrong value");
        }
        return arr;
    }

    public void ChooseSort(int NumberOperation, int n, int minz, int maxz,int x,int s)
    {
        //Stopwatch
        Stopwatch stopWatch = new Stopwatch();

        if (s==1) {Console.WriteLine("InsertionSort");}
        else if(s==2) {Console.WriteLine("MergeSort");}
        else if(s==3) {Console.WriteLine("QuickSortClassical");}
        else if(s==4) {Console.WriteLine("QuickSort");}
        else { Console.WriteLine("wrong value"); }
        int[] arr = new int[n];
        arr = ChooseArray(arr, x, n, minz, maxz);
        int[][] narr = new int[NumberOperation][];
        double[] nts1 = new double[NumberOperation];

        List<double> timelist = new List<double>();

        for (int i = 0; i < NumberOperation; i++)
        {
            narr[i] = (int[])arr.Clone();
        }
        PrintSort ob = new PrintSort();

        for (int i = 0; i < NumberOperation; i++)
        {
            if (s == 1)
            {
                stopWatch.Restart();
                ob.sort(narr[i]); //InserionSort
                stopWatch.Stop();
            }
            else if (s == 2)
            {
                stopWatch.Restart();
                ob.sort2(narr[i], 0, narr[i].Length - 1); //MergeSort
                stopWatch.Stop();
            }
            else if (s == 3)
            {
                stopWatch.Restart();
                quickSort3(narr[i], 0, narr[i].Length - 1); // QuickSortClassical
                stopWatch.Stop();
            }
            else if (s == 4)
            {
                stopWatch.Restart();
                Array.Sort(narr[i]); //QuickSort
                stopWatch.Stop();
            }
            else { Console.WriteLine("Wrong value"); }
            TimeSpan ts1 = stopWatch.Elapsed;

            nts1[i] = Convert.ToDouble(ts1.TotalMilliseconds);
            timelist.Add(nts1[i]);
        }
        Console.WriteLine("Average Time (ms)");
        Console.WriteLine(Math.Round(averageTime(nts1, NumberOperation),6));

        Console.WriteLine("Standard Deviation");
        Console.WriteLine(Math.Round(standardDeviation(timelist),6));
        timelist.Clear();

        if (s == 4 &&  n<50)
        {
        Console.WriteLine("\nGiven array");
        printArray(arr);
        Console.WriteLine("Sorted array");
        printArray(narr[0]);
        }

        Console.WriteLine();
    }

    public void Print(int NumberOperation, int n,int minz,int maxz,string text,int x)
    {
        Console.WriteLine("{3} between {2}-{1} n={0}\n", n, maxz, minz, text);
        ChooseSort(NumberOperation, n, minz, maxz, x, 1);
        ChooseSort(NumberOperation, n, minz, maxz, x, 2);
        ChooseSort(NumberOperation, n, minz, maxz, x, 3);
        ChooseSort(NumberOperation, n, minz, maxz, x, 4);
    }
    
}

