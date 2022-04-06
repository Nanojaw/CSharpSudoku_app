using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CliWrap;

namespace Sudoku;

/// <summary>
///     This is where the magic happens
/// </summary>
public sealed class CBackend
{
#region IsaksFunctions

    /// <summary>
    /// Generates a valid sudoku in the right format
    /// </summary>
    /// <returns>List of ints</returns>
    public List<int> GenerateSudoku()
    {
        var sudoku = GeneratexSudokuBackend().Result;

        return StrToIntListSudoku(sudoku);
    }

    /// <summary>
    /// Solves a supplied sudoku and returns the solved puzzle in the right format
    /// </summary>
    /// <param name="sudoku"></param>
    /// <returns>List of ints</returns>
    public List<int> SolveSudoku(List<int> sudoku)
    {
        var solvedSudoku = SolveSudokuBackend(IntListToStrSudoku(sudoku)).Result;

        return StrToIntListSudoku(solvedSudoku);
    }

#endregion
    
#region backend functions

    /// <summary>
    /// Converts string to int list sudoku
    /// </summary>
    /// <param name="sudokuStr"></param>
    /// <returns>Int list</returns>
    /// <exception cref="ArgumentNullException"></exception>
    private List<int> StrToIntListSudoku(string sudokuStr)
    {
        var sudokuIntList = new List<int>();
        if (sudokuIntList == null) throw new ArgumentNullException(nameof(sudokuIntList));

        foreach (var c in sudokuStr)
        {
            if (c != '.')
            {
                sudokuIntList.Add((int)char.GetNumericValue(c));
                continue;
            }

            sudokuIntList.Add(-1);
        }

        return sudokuIntList;
    }

    /// <summary>
    /// Converts int list to string sudoku
    /// </summary>
    /// <param name="sudokuIntLList"></param>
    /// <returns>String</returns>
    private string IntListToStrSudoku(List<int> sudokuIntLList)
    {
        var sudokuStr = "";

        foreach (var i in sudokuIntLList)
        {
            if (i != -1)
            {
                sudokuStr += i.ToString();
                continue;
            }

            sudokuStr += '.';
        }

        return sudokuStr;
    }

    private async Task<string> GeneratexSudokuBackend()
    {
        var stdOutBuffer = new StringBuilder();

        var app = "1" | Cli.Wrap("a.exe") | stdOutBuffer;
        await app.ExecuteAsync();

        return stdOutBuffer.ToString();
    }

    private async Task<string> SolveSudokuBackend(string sudoku)
    {
        var stdOutBuffer = new StringBuilder();

        var app = ("2 " + sudoku) | Cli.Wrap("a.exe") | stdOutBuffer;
        await app.ExecuteAsync();

        return stdOutBuffer.ToString();
    }

#endregion
}