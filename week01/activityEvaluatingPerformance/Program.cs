using System;

public static class ActivityDetermineBigO
{

    static void Main(string[] args)
    {
        Console.WriteLine("This function is O(n).");
        DoSomething(5);

        Console.WriteLine("This function is O(n^2).");
        DoSomethingElse(new List<string> { "Melon", "Fresa", "Mango" });

        Console.WriteLine("This function is O(n).");
        DoAnotherThing(new List<string> { "Melon", "Fresa", "Mango" });


        static void DoSomething(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(n * n);
            }

            for (int i = n; i > 0; i--)
            {
                Console.WriteLine(n * n * n);
            }
        }
    }

    static void DoSomethingElse(List<string> words)
    {
        for (int i = 0; i < words.Count; i++)
        {
            for (int j = 0; j < words.Count; j++)
            {
                Console.Write(".");
            }
        }

    }

    static void DoAnotherThing(List<string> words)
    {
        string sentence = "The quick brown fox jumps over the lazy dog";
        for (int i = 0; i < words.Count; i++)
        {
            for (int j = 0; j < sentence.Length; j++)
            {
                Console.Write("*");
            }
        }
    }
}