using System;

using static System.Console;

namespace Exercise
{
    class ConsoleDisplayer
    {
        static char displayChar = '*';
        
        static void DisplaySquare(int row, int column)
        {
            const int maxRow = 50;
            const int maxColumn = 50;

            row = (row > maxRow) ? maxRow : row;
            column = (column > maxColumn) ? maxColumn : column;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Write(displayChar.ToString());
                }
                WriteLine();
            }
        }
    }
}