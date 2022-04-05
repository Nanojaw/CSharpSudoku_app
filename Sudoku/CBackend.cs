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
#region Public funtions to be used elsewhere

    public List<int> GenerateSudoku()
    {
        var sudokuStr = GeneratexSudokuBackend().Result;

        return StrToIntListSudoku(sudokuStr);
    }

    public List<int> SolveSudoku(List<int> sudoku)
    {
        var solvedSudokuStr = SolveSudokuBackend(IntListToStrSudoku(sudoku)).Result;

        return StrToIntListSudoku(solvedSudokuStr);
    }

#endregion

#region backend functions

    public List<int> StrToIntListSudoku(string sudokuStr)
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

    public string IntListToStrSudoku(List<int> sudokuIntLList)
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

        var app = "2" | Cli.Wrap("a.exe").WithArguments(sudoku) | stdOutBuffer;
        await app.ExecuteAsync();

        return stdOutBuffer.ToString();
    }

#endregion
}