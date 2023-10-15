using System.Diagnostics;
using ChessLibrary.GameFigures;

namespace ChessLibrary;

//delegate for running Board.IdentifySegment() static method.
public delegate string IdentifyBoardSegment(Board boardObj);

public class Board
{
    #region properties
    //local property of figure objects
    public IFigure[] Figures { get; set; }

    //only figure names are on the board. only the figure name will be nulled and rewritten on the board
    public string[,] BoardWithFigures { get; set; } = new string[8, 8];

    //figure names and legal steps are on the board. this board will be nulled and refilled by each step.
    public string[,] BoardWithFiguresSteps { get; set; } = new string[8, 8];

    //contains  figures' string names
    public static string[] FigureNames = new[] { "a", "b", "c", "d", "e" };

    public static string[] whiteFigureNames = new[] { "a", "b", "c", "d" };

    //contains objects of the rooks, for rook defence strategy
    public IFigure[] whiteRooks = new IFigure[2];

    //contains string symbols of white figures
    public static string[] whitefiguresSymbols = new []{"1", "2", "3", "4"};

    
    //string type variable representing the segment of the board(based on the positions of two kings)
    public static IdentifyBoardSegment delSegment = new IdentifyBoardSegment(IdentifySegment);
    
    #endregion
    

    
    //parameterized copy constructor
    public Board(Board boardObj)
    {
        Figures = boardObj.Figures;
        BoardWithFigures = (string[,])boardObj.BoardWithFigures.Clone();
        BoardWithFiguresSteps = (string[,])boardObj.BoardWithFiguresSteps.Clone();
    }
    
    //parameterized constructor for createing Board type objects based on array of IFigure type objects
    public Board(IFigure[] figures)
    {
        Figures = figures;
        NullBoard(BoardWithFigures);
        NullBoard(BoardWithFiguresSteps);

        foreach(IFigure figure in figures)
            WriteFigureOnBoard(figure, BoardWithFigures);

        BoardWithFiguresSteps = AddAllLegalSteps(figures, BoardWithFigures, BoardWithFiguresSteps);
        BoardPrinterForDebug(BoardWithFiguresSteps);
    }

    /// <summary>
    /// Prints figures on string[,] board.
    /// </summary>
    /// <param name="figure">class object implementing IFigure interface.</param>
    public static void WriteFigureOnBoard(IFigure figure, string[,] board)
    {
        //write figures on BoardWithFigures
        board[figure.Row, figure.Column] = figure.Name;
    }

    /// <summary>
    /// Adds figures' legal steps.
    /// </summary>
    /// <param name="boardToCopy">string type two-dimensonal array to copy from.</param>
    // refactor - return board, or object
    public static void WriteLegalStepsOnBoard(IFigure figure, string[,] board)
    {
        figure.AddLegalSteps(board);
    }

    //identifying the segment where Black king is separated from the White King, HARD CODE
    public static string IdentifySegment(Board boardObj)
    {
        IFigure wk = boardObj.Figures[0];
        IFigure bk = boardObj.Figures[4];
        string segment;
        if (wk.Row - bk.Row > 0)
        {
            segment = "upper";
        }
        else if (bk.Row - wk.Row > 0)
        {
            segment = "lower";
        }
        else if (wk.Column - bk.Column >1)
        {
            segment = "left";
        }
        else
        {
            segment = "right";
        }
        return segment;
    }

    /// <summary>
    /// Adds the legal steps of all figures to static board BoardWithFiguresSteps.
    /// </summary>
    /// <param name="figures">Array of IFigyre type elements.</param>
    public static string[,] AddAllLegalSteps(IFigure[] figures, string[,] boardFrom, string[,] boardTo)
    {
        //clone BoardWithFigures to BoardWithFiguresSteps 
        boardTo = (string[,])boardFrom.Clone();

        //write legal steps on a new board
        foreach (IFigure elem in figures)
        {
            WriteLegalStepsOnBoard(elem, boardTo);
        }
        return boardTo;
    }

    /// <summary>
    /// Updates board: first it makes null current position on the BoardWithFigures
    /// then re-writes BoardWithFiguresSteps array with new figures and steps.
    /// </summary>
    /// <param name="figures"> IFigure type two-dimensional array.</param>
    /// <param name="figure">IFigure type object.</param>
    /// <param name="destRow">Destination row coordinate.</param>
    /// <param name="destColumn">Destination column coordinate.</param>
    public static Board UpdateBoard(Board boardObj, IFigure[] figures, IFigure figure, int destRow, int destColumn)
    {
        switch(figure.Name)
        {
            case "a":
                King figureToMoveWk = new King(Coordinates.Create2DArrayByCoordinates(destRow, destColumn), "white");
                figures[1] = (IFigure)figureToMoveWk;
                break;
            case "b":
                Queen figureToMoveQ = new Queen(Coordinates.Create2DArrayByCoordinates(destRow, destColumn));
                figures[1] = (IFigure)figureToMoveQ;
                break;
            case "c":
                Rook figureToMoveR1 = new Rook(Coordinates.Create2DArrayByCoordinates(destRow, destColumn), "1");
                figures[2] = (IFigure)figureToMoveR1;
                break;
            case "d":
                Rook figureToMoveR2 = new Rook(Coordinates.Create2DArrayByCoordinates(destRow, destColumn), "2");
                figures[3] = (IFigure)figureToMoveR2;
                break;
            case "e":
                King figureToMoveBK = new King(Coordinates.Create2DArrayByCoordinates(destRow, destColumn), "black");
                figures[4] = (IFigure)figureToMoveBK;
                break;
        }
        
        boardObj = new Board(figures);
        return boardObj;
    }

    /// <summary>
    /// This method will allow to see the board with figure names and legals teps in CONSOLE 
    /// custom mode of debugger to better understand the process.
    /// In this regard an attribute is used to restrict the usage of the method for "Console" custom mode only.
    /// </summary>
    /// <param name="board">String type two-dimensional array representing current chess board.</param>
    [Conditional("CONSOLE")]
    public static void BoardPrinterForDebug(string[,] board)
    {
        int count = 1;
        Console.WriteLine("     A    B    C    D    E    F    G    H ");
        for (int i = 0; i < 8; i++)
        {
            Console.Write($" {count}  ");
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

                if (board[i, j] == null)
                    Console.Write("     ");
                else
                {
                    if (whiteFigureNames.Contains(board[i, j][0].ToString()))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(board[i, j].PadRight(5));
                        Console.ResetColor();
                    }
                    else if (board[i, j].Contains("e"))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(board[i, j].PadRight(5));
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(board[i, j].PadRight(5));
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    public static string[,] NullBoard(string[,] board)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[i, j] != null)
                    board[i, j] = null;
            }
        }
        return board;
    }
}