using System;
using System.Collections.Generic;

namespace Sudoku
{
    /// <summary>
    /// Isaks functions lel
    /// </summary>
    public static class Backend
    {
        /// <summary>
        /// Generates Sudoku;
        /// </summary>
        /// <returns> List of ints </returns>
        public static List<int> GenerateSudoku()
        {
            var sudokuBoard = new SudokuBoard();

            sudokuBoard.Solver.SolveThePuzzle(UseRandomGenerator: true);

            var sudokuPuzzle = new List<int>();

            sudokuBoard.Cells.ForEach(cell => sudokuPuzzle.Add(cell.Value));

            return sudokuPuzzle;
        }
    }
}