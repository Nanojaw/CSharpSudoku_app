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
        private static readonly Dictionary<int, int> ToSquare = new Dictionary<int, int>(){
            {0, 0}, {1, 0}, {2, 0}, {3, 3}, {4, 3}, {5, 3}, {6, 6}, {7, 6}, {8, 6},
            {9, 0}, {10, 0}, {11, 0}, {12, 3}, {13, 3}, {14, 3}, {15, 6}, {16, 6}, {17, 6},
            {18, 0}, {19, 0}, {20, 0}, {21, 3}, {22, 3}, {23, 3}, {24, 6}, {25, 6}, {26, 6},

            {27, 27}, {28, 27}, {29, 27}, {30, 30}, {31, 30}, {32, 30}, {33, 33}, {34, 33}, {35, 33},
            {36, 27}, {37, 27}, {38, 27}, {39, 30}, {40, 30}, {41, 30}, {42, 33}, {43, 33}, {44, 33},
            {45, 27}, {46, 27}, {47, 27}, {48, 30}, {49, 30}, {50, 30}, {51, 33}, {52, 33}, {53, 33},

            {54, 54}, {55, 54}, {56, 54}, {57, 57}, {58, 57}, {59, 57}, {60, 60}, {61, 60}, {62, 60},
            {63, 54}, {64, 54}, {65, 54}, {66, 57}, {67, 57}, {68, 57}, {69, 60}, {70, 60}, {71, 60},
            {72, 54}, {73, 54}, {74, 54}, {75, 57}, {76, 57}, {77, 57}, {78, 60}, {79, 60}, {80, 60},
        };

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

        /// <summary>
        /// Checks if ou can insert the number at the specifiedindex
        /// </summary>
        /// <param name="sudoku">The sudoku board</param>
        /// <param name="number">The number to fit</param>
        /// <param name="index"> The index of the number</param>
        /// <returns></returns>
        public static bool Fits(List<int> sudoku, int number, int index)
        {
            // Horizontal check
            for (var i = 0; i < 9; i++)
            {
                if (sudoku[i + (index / 9) * 9] == number) return false;
            }

            for (var i = 0; i < 9; i++)
            {
                if (sudoku[i * 9 + (index % 9)] == number) return false;
            }

            var square = ToSquare[index];
            for (var i = 0; i < 27; i += 9)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (sudoku[square + i + j] == number) return false;
                }
            }

            return true;
        }
    }
}