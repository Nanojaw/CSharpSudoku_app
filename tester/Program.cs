using System;
using Sudoku;

namespace tester // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Sudoku.SudokuBoard gameBoard = new SudokuBoard();
            gameBoard.Solver.SolveThePuzzle(UseRandomGenerator: true);

            foreach (var cell in gameBoard.Cells)
            {
                Console.WriteLine(cell.Value);
            }
        }
    }
}