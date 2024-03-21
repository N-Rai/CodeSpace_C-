using System;

public class PrefixSum
{
    public int[] prefixSumArray;

    public PrefixSum(int[] arr)
    {
        ConstructPrefixSum(arr);
    }

    private void ConstructPrefixSum(int[] arr)
    {
        int n = arr.Length;
        prefixSumArray = new int[n + 1]; // Create an array for prefix sums

        prefixSumArray[0] = 0; // Initialize the prefix sum at index 0 to 0

        // Compute prefix sums
        for (int i = 1; i <= n; i++)
        {
            prefixSumArray[i] = prefixSumArray[i - 1] + arr[i - 1];
        }
    }

    public int GetSumInRange(int left, int right)
    {
        if (left < 0 || right >= prefixSumArray.Length || left > right)
            throw new ArgumentOutOfRangeException("Invalid range");

        // The sum of elements from index left to right (inclusive) is the difference
        // between prefix sum at index right + 1 and prefix sum at index left
        return prefixSumArray[right + 1] - prefixSumArray[left];
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        PrefixSum prefixSum = new PrefixSum(arr);

        Console.WriteLine("Prefix sums:");
        foreach (var sum in prefixSum.prefixSumArray)
        {
            Console.Write(sum + " ");
        }
        Console.WriteLine();

        // Example usage of GetSumInRange
        Console.WriteLine("Sum from index 1 to 3: " + prefixSum.GetSumInRange(1, 3));
        Console.WriteLine("Sum from index 0 to 4: " + prefixSum.GetSumInRange(0, 4));

        // More exercises can be added here
    }
}
