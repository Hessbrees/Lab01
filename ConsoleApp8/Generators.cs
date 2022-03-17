// C# program for implementation of Insertion Sort
using System;

public static class Generators
{
	public static int[] GenerateRandom(int size, int minVal, int maxVal)
	{
		int[] a = new int[size];
		for (int i =0; i<size; i++)
        {
			Random rnd = new Random();
			a[i] = rnd.Next(minVal, maxVal+1);
		}
    return a;
	}
	public static int[] GenerateSorted(int size, int minVal, int maxVal)
	{
		int[] a = GenerateRandom(size, minVal, maxVal);
		Array.Sort(a);
		return a;
	}
	public static int[] GenerateReversed(int size, int minVal, int maxVal)
	{
		int[] a = GenerateSorted(size, minVal, maxVal);
		Array.Reverse(a);
		return a;
	}

	public static int[] GenerateAlmostSorted(int size, int minVal, int maxVal)
	{
		int[] a = GenerateRandom(size, minVal, maxVal);
		Array.Sort(a);
		int changedvalues = size / 10;
		if (changedvalues == 0) { changedvalues = 1; }
		for (int i = 0; i < changedvalues; i++)
		{
			Random rnd = new Random();
			Random rnd2 = new Random();

			a[rnd2.Next(0,size)] = rnd.Next(minVal, maxVal + 1);
		
		}
		return a;
	}
}

