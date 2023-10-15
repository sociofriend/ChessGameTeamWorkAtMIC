using System.Diagnostics;
using System.Net.NetworkInformation;

namespace ChessLibrary.GameFigures;

public class King : IFigure
{
    #region properties
    public string AlgebraicNotation { get; set; }
    public string Name { get; set; }
    public int[,] Coordinates { get; set; }
    public string[,] LegalSteps { get; set; } = new string[8, 8];
    public int FigureNumber { get; set; }
    public string FigureNumberString { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public string StepSymbol { get; set; }
    public List<int> TwoDigitSteps { get; set; }
    public int[] NumbersForLegalSteps;
    #endregion

    /// <summary>
    /// Parameterised constructor initialises all local fields.
    /// </summary>
    /// <param name="coordinatesInput">Integer type two-dimensional array carrying data
    /// input for figure position.</param>
    public King(int[,] coordinatesInput, string name)
    {
        Coordinates coordinatesObj = new Coordinates(coordinatesInput);
        Coordinates = coordinatesInput;
        FigureNumber = coordinatesObj.FigureNumber;
        FigureNumberString = coordinatesObj.FigureNumberString;
        Row = coordinatesObj.Row;
        Column = coordinatesObj.Column;
        NumbersForLegalSteps = new int[] { -11, -10, -9, -1, 1, 9, 10, 11 };

        if (name == "white")
        {
            Name = "a";
            StepSymbol = "1";
        }

        else if (name == "black")
        {
            Name = "e";
            StepSymbol = "5";
        }
    }

    /// <summary>
    /// Adds king's name by user input coordinates on the given board.
    /// </summary>
    /// <param name="king">King type object</param>
    /// <param name="board">String type two-dimensional array representing chessboard with figure names.</param>
    public static void AddKingCoordinates(King king, string[,] board)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[i, j] == null)
                {
                    if (king.Name == "e")
                        board[i, j] = "e";
                    else
                        board[i, j] = "a";
                }
            }
        }
    }

    /// <summary>
    /// Adds legal steps of a king on the given board.
    /// </summary>
    /// <param name="board">Returns string type two-dimensional array representing chessboard with legal steps.</param>
    public void AddLegalSteps(string[,] board)
    {
        if (board[Row, Column] == null/* || board[Row, Column] == Name*/)
        {
            board[Row, Column] = Name;
        }
        else if (board[Row, Column] != null && !board[Row, Column].Contains(Name))
        {
            board[Row, Column] += Name;
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[i, j] == null &&
                   NumbersForLegalSteps.Contains(FigureNumber - ChessLibrary.Coordinates.ConvertCoordinatesToNumber(i, j)))
                {
                    board[i, j] += StepSymbol;///
                }
                else if (board[i, j] != "e" && board[i, j] != "5" &&
                    NumbersForLegalSteps.Contains(FigureNumber - ChessLibrary.Coordinates.ConvertCoordinatesToNumber(i, j)))
                {
                    board[i, j] += StepSymbol;
                }
            }
        }
    }
    /// <summary>
    /// Checks if a figure (protected) is protected, aka whether the field contains step symbols of other white figure.
    /// </summary>
    /// <param name="boardObj">Board type object representing everything related to board and figures.</param>
    /// <param name="protectable">IFigure type object to be pchecked for protection.</param>
    /// <returns>Returns boolean type value.</returns>
    public bool IsProtected(Board boardObj, IFigure protectable)
    {
        return true;
    }

    /// <summary>
    /// Check whether the field of defend-needing figure field contains the step symbol of attacking figure
    /// </summary>
    /// <param name="bk">Attacking figure object.</param>
    /// <param name="figure1">Figure to be checked for attack of attacker.</param>
    /// <param name="board">Board type object representing chess board and everything related to it.</param>
    /// <returns>Returns boolean type value.</returns>
    public bool FigureUnderAttack(IFigure bk, IFigure figure1, string[,] board)
    {
        return true;
    }

    /// <summary>
    /// Checks the null value of the BK destionation coordinates. If null - the king is not under attack.
    /// </summary>
    /// <param name="newCoordinatesBK">New destination coordiantes for the Black King from the user input.</param>
    /// <returns>Boolean type value.</returns>
    public static bool KingIsNotUnderAttack(King bk, string[,] board)
    {
        if (board[bk.Row, bk.Column] == null || board[bk.Row, bk.Column].Equals(bk.StepSymbol))
            return true;
        else
            return false;
    }

    /// <summary>
    /// Checks, whether black king(aka black figure for future) figure has legal step to move.
    /// Two cases are described in the method.1)an empty field, 2) a filed already ocupied with black figure. 
    /// </summary>
    /// <param name="boardObj">Board type object representing chess board's current state and descriptions.</param>
    /// <param name="figure">IFigure type figure, in this case representing black king, in the future any black figure.</param>
    /// <returns>Returns boolean: true if there is a legal step, and false vice versa.</returns>
    public bool HasLegalSteps(Board boardObj, IFigure figure)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (boardObj.BoardWithFiguresSteps[i, j] != null &&
                    boardObj.BoardWithFiguresSteps[i, j].Contains(figure.StepSymbol))
                {
                    if (!boardObj.BoardWithFiguresSteps[i, j].Contains("1") &&               //Hard Code
                        !boardObj.BoardWithFiguresSteps[i, j].Contains("2")&&
                        !boardObj.BoardWithFiguresSteps[i, j].Contains("3") &&
                         !boardObj.BoardWithFiguresSteps[i, j].Contains("4"))
                    {
                        //shouldBreak = true;
                        return true;
                    }

                }
            }
        }
        return false;
    }

    /// <summary>
    /// Checks a figure being under attack, aka figure's field contains a step symbol of opposite color figure.
    /// </summary>
    /// <param name="boardObj">Board type object representing chess board and everything related to it.</param>
    /// <param name="figureUnderAttack">IFigure type object to be checked.</param>
    /// <returns>Returns boolean type value.</returns>
    public bool IsUnderAttack(Board boardObj, IFigure figureUnderAttack)
    {
        if (boardObj.BoardWithFiguresSteps[figureUnderAttack.Row, figureUnderAttack.Column] != null &&
        boardObj.BoardWithFiguresSteps[figureUnderAttack.Row, figureUnderAttack.Column].Length == 1 &&
        boardObj.BoardWithFiguresSteps[figureUnderAttack.Row, figureUnderAttack.Column].Contains(figureUnderAttack.StepSymbol))
        {
            return false;
        }

        return true;
    }
}
