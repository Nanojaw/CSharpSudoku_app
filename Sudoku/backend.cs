using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    /// <summary>
    /// Isaks functions lel
    /// </summary>
    public static class Backend
    {
        /// <summary>
        /// Generates Sudoku;
        /// Uses a variable toBeFilled to denote how many percent of the board the generator should fill
        /// </summary>
        /// <returns> List of ints </returns>
        public static List<int> GenerateSudoku(double toBeFilled)
        {
            var randomNumberGenerator = new Random();

            var toBeRemoved = 1 - toBeFilled;
            var numOfDeletions = Math.Floor(toBeRemoved * 81);

            var sudokuBoard = new SudokuBoard();

            sudokuBoard.Solver.SolveThePuzzle();

            for (int i = 0; i < numOfDeletions; i++)
            {
                var cellIndex = randomNumberGenerator.Next(0, 80);

                while (sudokuBoard.GetCell(cellIndex).Value == -1)
                {
                    cellIndex = randomNumberGenerator.Next(0, 80);
                }

                sudokuBoard.SetCellValue(-1, cellIndex);
            }

            while (!sudokuBoard.Solver.CheckTableStateIsValid())
            {
                sudokuBoard.Clear();

                sudokuBoard.Solver.SolveThePuzzle();

                for (int i = 0; i < numOfDeletions; i++)
                {
                    var cellIndex = randomNumberGenerator.Next(0, 80);

                    while (sudokuBoard.GetCell(cellIndex).Value == -1)
                    {
                        cellIndex = randomNumberGenerator.Next(0, 80);
                    }

                    sudokuBoard.SetCellValue(-1, cellIndex);
                }
            }

            var sudokuPuzzle = new List<int>();

            sudokuBoard.Cells.ForEach(cell => sudokuPuzzle.Add(cell.Value));

            return sudokuPuzzle;
        }
    }
}