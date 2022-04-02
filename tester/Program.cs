using System;

namespace tester {
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var lel = backend.GenerateSudoku();

            Console.WriteLine(lel);
        }
    }
}