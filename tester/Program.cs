﻿using System;
using Sudoku;

namespace tester // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Gello World!");

            var lel = Backend.GenerateSudoku(0.5);


            lel.ForEach(v => Console.WriteLine(v));
        }
    }
}