using ChessLibrary;
namespace ChessProject;

public class BoardIllustrator
{
    /// <summary>
    /// Prints the chess board represente by two-dimensional array of string values.
    /// </summary>
    /// <param name="board">String type 2D array representing the chess board.</param>
    public static void PrintBoard(string[,] board)
    {
        int count = 1;
        Console.WriteLine("    A  B  C  D  E  F  G  H ");
        for (int i = 0; i < 8; i++)
        {
            Console.Write($" {count} ");
            count++;
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                
                if(board[i,j] == null)
                    Console.Write("   ");
                else
                {
                    if(board[i,j].Length == 1)
                        Console.Write($" {board[i,j]} ");
                    else if(board[i,j].Length == 2)
                        Console.Write($"{board[i,j]} ");
                    else if(board[i,j].Length == 3)
                        Console.Write(board[i,j]);
                }
                
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}