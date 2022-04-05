using Sudoku;

namespace tester;

internal static class Program
{
    private static void Main(string[] args)
    {
        var backend = new CBackend();
        
        var SolveSudoku = backend.SolveSudoku(backend.StrToIntListSudoku(".5..83.17...1..4..3.4..56.8....3...9.9.8245....6....7...9....5...729..861.36.72.4"))
    }
}