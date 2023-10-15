using ChessLibrary.GameFigures;

namespace ChessLibrary;

public class Defence
{
    public static Board RunRookDefence(Board boardObj, List<IFigure> rooksToDefend)
    {
        string segment = Board.IdentifySegment(boardObj);
        if (segment == "upper" || segment == "lower")
        {
            boardObj = HorizontalDefendRook(boardObj, boardObj.Figures, rooksToDefend[0]);
        }
        else if (segment =="left"|| segment == "right") 
        {
            boardObj = VerticalDefendRook(boardObj, boardObj.Figures, rooksToDefend[0]);

        }
        return boardObj;
    }

    /// <summary>
    /// Checks the defend needs of the rooks and adds to list the rook, needing protection.
    /// </summary>
    /// <param name="figures">IFigure type array.</param>
    /// <returns>Returns list of rooks needed to defend.</returns>
    public static List<IFigure> CheckRooks(IFigure[] figures, string[,] board)
    {

        //List to collect rooks needing protection
        List<IFigure> rooksToDefend = new List<IFigure>();
        IFigure[] rookArray = new ArraySegment<IFigure>(figures, 2, 2).ToArray();

        //check UnderAttack status for each rook. HARD CODE
        foreach (IFigure rook in rookArray)
        {
            if (rook.FigureUnderAttack(figures[4], rook, board))
            {
                rooksToDefend.Add(rook);
            }
        }

        return rooksToDefend;
    }

    /// <summary>
    /// Moves rook(under attack) to the farest cell from the black king. HARD CODE
    /// </summary>
    /// <param name="boardObj">Board type object.</param>
    /// <param name="figures">IFigure type elements' array representing figure objects.</param>
    /// <param name="rook">IFigure type object representing rook(under attack).</param>
    public static Board HorizontalDefendRook(Board boardObj, IFigure[] figures, IFigure rook)
    {
        IFigure bk = figures[4];

        if (bk.Column <= 3)
        {
            for (int i = 7; i > 3; i--)
            {
                if (boardObj.BoardWithFiguresSteps[rook.Row, i].Contains(rook.StepSymbol) &&
                !boardObj.BoardWithFiguresSteps[rook.Row, i].Contains("a") &&
                !boardObj.BoardWithFiguresSteps[rook.Row, i].Contains("b") &&
                !boardObj.BoardWithFiguresSteps[rook.Row, i].Contains("c") &&
                !boardObj.BoardWithFiguresSteps[rook.Row, i].Contains("d"))
                {
                    boardObj = Board.UpdateBoard(boardObj, figures, rook, rook.Row, i);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (boardObj.BoardWithFiguresSteps[rook.Row, i].Contains(rook.StepSymbol) &&
                !boardObj.BoardWithFiguresSteps[rook.Row, i].Contains("a") &&
                !boardObj.BoardWithFiguresSteps[rook.Row, i].Contains("b") &&
                !boardObj.BoardWithFiguresSteps[rook.Row, i].Contains("c") &&
                !boardObj.BoardWithFiguresSteps[rook.Row, i].Contains("d"))
                {
                    boardObj = Board.UpdateBoard(boardObj, figures, rook, rook.Row, i);
                    break;
                }
            }
        }
        return boardObj;
    }
    public static Board VerticalDefendRook(Board boardObj, IFigure[] figures, IFigure rook)
    {
        IFigure bk = figures[4];

        if (bk.Row <= 3)
        {
            for (int i = 7; i > 3; i--)
            {
                if (boardObj.BoardWithFiguresSteps[i, rook.Column].Contains(rook.StepSymbol) &&
                !boardObj.BoardWithFiguresSteps[i, rook.Column].Contains("a") &&
                !boardObj.BoardWithFiguresSteps[i, rook.Column].Contains("b") &&
                !boardObj.BoardWithFiguresSteps[i, rook.Column].Contains("c") &&
                !boardObj.BoardWithFiguresSteps[i, rook.Column].Contains("d"))
                {
                    boardObj = Board.UpdateBoard(boardObj, figures, rook, i, rook.Row);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (boardObj.BoardWithFiguresSteps[i, rook.Column].Contains(rook.StepSymbol) &&
                !boardObj.BoardWithFiguresSteps[i, rook.Column].Contains("a") &&
                !boardObj.BoardWithFiguresSteps[i, rook.Column].Contains("b") &&
                !boardObj.BoardWithFiguresSteps[i, rook.Column].Contains("c") &&
                !boardObj.BoardWithFiguresSteps[i, rook.Column].Contains("d"))
                {
                    boardObj = Board.UpdateBoard(boardObj, figures, rook, i, rook.Row);
                    break;
                }
            }
        }
        return boardObj;
    }

    //receives figure object as argument, and checks on the static StepsFigures array of board class 
    //also used to check the Shakh status for the BLACK KING
    public static bool FigureUnderAttack(Board boardObj, King attacker, IFigure defender)
    {
        if (boardObj.BoardWithFiguresSteps[defender.Row, defender.Column].Contains(attacker.StepSymbol))
            return true;
        return false;
    }

    //Checks whether the figure is in shach? for black king - looks in steps of all white figures, 
    //for white figures only looks in the legal steps of black king
    public static bool CheckShakhAndMate(Board boardObj, IFigure figureUnderShach)
    {
        //implement a separate method identifying if the figure has legal steps and if it is underattack
        if (IsUnderShakh(boardObj, figureUnderShach) == true &&
            figureUnderShach.HasLegalSteps(boardObj, figureUnderShach) == false)
            return true;
        return false;
    }

    //checks whether the figure is undeer PAT, useful for black king
    public static bool CheckPat(Board boardObj, IFigure attacker, int row, int column)
    {
        //Board boardObj2 = new Board(boardObj);

        //foreach(IFigure figure in boardObj2.Figures)
        //{
        //    if (figure.Name == attacker.Name)
        //    {
        //        boardObj2 = Board.UpdateBoard(boardObj2, boardObj2.Figures, figure, row, column);
        //        break;
        //    }
        //}

        //if (boardObj2.Figures[4].HasLegalSteps(boardObj2, boardObj2.Figures[4]))
        if (boardObj.Figures[4].HasLegalSteps(boardObj, boardObj.Figures[4]))
            return false;
        else
            return true;
    }

    public static bool IsUnderShakh(Board boardObj, IFigure figureUnderAttack)
    {
        if (boardObj.BoardWithFiguresSteps[figureUnderAttack.Row, figureUnderAttack.Column] != null &&
        boardObj.BoardWithFiguresSteps[figureUnderAttack.Row, figureUnderAttack.Column].Length == 1 &&
        boardObj.BoardWithFiguresSteps[figureUnderAttack.Row, figureUnderAttack.Column].Contains(figureUnderAttack.Name))
        {
            return false;
        }

        return true;
    }
}


