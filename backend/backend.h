#pragma once

// Function for generating sudokus
const char* GenerateSudoku();

// Functions for generating hexadecimal sudokus
const char* GenerateHexSudoku();

// The GenerateSudoku function should return a 162 characters long array.
// The first 81 characters should be the playable sudoku, with values between 1 and 9, using 0 as blank
// The last 81 characters should be the finished sudoku, not containing any blanks

// The same applies for GenerateHexSudoku, but its returned array should be 512 characters, 256 for each sudoku, using 16 as blank

enum sudokutype
{
    sudoku,
    hex_sudoku
};

// Freeing the native memory
void Free(sudokutype type);

// Filing
const char* LoadSudoku();
const char* LoadHexSudoku();

void SaveSudoku();
void SaveHexSudoku();
