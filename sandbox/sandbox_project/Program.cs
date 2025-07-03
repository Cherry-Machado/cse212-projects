using System;

public class Program
{

    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");

        DoSomething(79);


        static void DoSomething(int n)
        {
            for (int i = 1; i < n; i++)
            {
                int resi = n % i;
                if (resi == 0)
                {
                    Console.WriteLine(i);
                }
                ;

            }
        }
    }

}