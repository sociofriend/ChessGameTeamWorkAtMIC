using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Channels;
using ChessLibrary.GameFigures;
namespace ChessLibrary;
public class Attack
{
    /// <summary>
    /// Depending on segment of black king, organizes 1st level attack(cutting black king from white king segment)
    /// Depending on segment two strategies for attack are proposed: Horizontal and Vertical.
    /// </summary>
    /// <param name="boardObj">Board type object representing chess board and everything related to it.</param>
    /// <returns>Returns new Board type object with 1st level attack implemented.</returns>
    public static Board FirstAttackBySegment(Board boardObj, string segment, List<IFigure> whiteAttackers)
    {
        int coordinate = 0;
        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        switch (segment)
        {
            case "upper":
                {
                    coordinate = bk.Row + 1;
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers, 3);
                    break;
                }
            case "lower":
                {
                    coordinate = bk.Row - 1;
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers, 3);
                    break;
                }
            case "left":
                {
                    coordinate = bk.Column + 1;
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 3);
                    break;
                }
            case "right":
                {
                    coordinate = bk.Column - 1;
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 3);
                    break;
                }
        }
        return boardObj;
    }
    /// <summary>
    /// Organizes 2nd level attack placing a second white figure on the opposite side.
    /// </summary>
    /// <param name="boardObj">Board type object representing chess board and everything related to it.</param>
    /// <returns>Returns new Board type object with 1st level attack implemented.</returns>
    public static Board SecondAttackBySegment(Board boardObj, string segment, List<IFigure> whiteAttackers)
    {
        int coordinate = 0;
        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        switch (segment)
        {
            case "upper":
                {
                    coordinate = bk.Row - 1;
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers, 2);
                    break;
                }
            case "lower":
                {
                    coordinate = bk.Row + 1;
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers, 2);
                    break;
                }
            case "left":
                {
                    coordinate = bk.Column - 1;
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 2);
                    break;
                }
            case "right":
                {
                    coordinate = bk.Column + 1;
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 2);
                    break;
                }
        }
        return boardObj;
    }
    /// <summary>
    /// Organizes 3rd level attack placing a third figure on black king row/coumn if black king stayed on the initial row.
    /// </summary>
    /// <param name="boardObj">Board type object representing chess board and everything related to it.</param>
    /// <returns>Returns new Board type object with 1st level attack implemented.</returns>
    public static Board ThirdAttackBySegment(Board boardObj, string segment, List<IFigure> whiteAttackers)
    {
        int coordinate = 0;
        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        switch (segment)
        {
            case "upper":
            case "lower":
                {
                    coordinate = bk.Row;
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                    break;
                }
            case "left":
            case "right":
                {
                    coordinate = bk.Column;
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                    break;
                }

        }
        return boardObj;
    }
    /// <summary>
    /// Organizes 4th level placing a white figure on BK row/column, if Chack and Mate was not achieved on 3rd level of attack.
    /// This is the final stage of endgame.
    /// </summary>
    /// <param name="boardObj">Board type object representing chess board and everything related to it.</param>
    /// <returns>Returns new Board type object with 1st level attack implemented.</returns>
    public static Board FourthAttackBySegment(Board boardObj, string segment, List<IFigure> whiteAttackers)
    {
        int coordinate = 0;
        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        switch (segment)
        {
            case "upper":
            case "lower":
                {
                    coordinate = bk.Row;
                    foreach (IFigure figure in whiteAttackers)
                    {
                        if (Math.Abs(figure.Row - bk.Row) == 2)
                        {
                            whiteAttackers.Insert(0, figure);
                            boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                            break;
                        }
                    }
                    break;
                }
            case "left":
            case "right":
                {
                    coordinate = bk.Column;
                    foreach (IFigure figure in whiteAttackers)
                    {
                        if (Math.Abs(figure.Column - bk.Column) == 2)
                        {
                            whiteAttackers.Insert(0, figure);
                            boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                            break;
                        }
                    }
                    break;
                }
        }
        return boardObj;
    }
    public static Board Attack02(Board boardObj, string segment, List<IFigure> whiteAttackers)
    {
        int coordinate = 0;
        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        switch (segment)
        {
            case "upper":
                {
                    if (whiteAttackers[1].Row - bk.Row == 1)
                    {
                        coordinate = bk.Row;
                    }
                    else
                    {
                        coordinate = bk.Row + 1;
                    }
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                    break;
                }
            case "lower":
                {
                    if (whiteAttackers[1].Row - bk.Row == -1)
                    {
                        coordinate = bk.Row;
                    }
                    else
                    {
                        coordinate = bk.Row - 1;
                    }
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                    break;
                }
            case "left":
                {
                    if (whiteAttackers[1].Column - bk.Column == -1)
                    {
                        coordinate = bk.Column;
                    }
                    else
                    {
                        coordinate = bk.Row - 1;
                    }
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                    break;
                }
            case "right":
                {
                    if (whiteAttackers[1].Column - bk.Column == 1)
                    {
                        coordinate = bk.Column;
                    }
                    else
                    {
                        coordinate = bk.Row + 1;
                    }
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                    break;
                }

        }
        return boardObj;
    }
    public static Board Attack03(Board boardObj, string segment, List<IFigure> whiteAttackers)
    {
        int coordinate = 0;
        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        switch (segment)
        {
            case "upper":
                {

                    if (whiteAttackers[0].Row - bk.Row == 3)
                    {
                        if (whiteAttackers[0].Column - bk.Column == 1)
                        {
                            if (Defence.CheckPat(boardObj, whiteAttackers[0], whiteAttackers[0].Row - 1, whiteAttackers[0].Column) == false)
                            {
                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, whiteAttackers[0], whiteAttackers[0].Row - 1, whiteAttackers[0].Column);
                            }
                            break;
                        }
                        else if (whiteAttackers[0].Column - bk.Column == -1)
                        {
                            if (Defence.CheckPat(boardObj, whiteAttackers[0], whiteAttackers[0].Row + 1, whiteAttackers[0].Column) == false)
                            {
                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, whiteAttackers[0], whiteAttackers[0].Row + 1, whiteAttackers[0].Column);
                            }
                            break;
                        }
                        else if (whiteAttackers[0].Column - bk.Column == 2)
                        {
                            if (Defence.CheckPat(boardObj, whiteAttackers[0], whiteAttackers[0].Row - 1, whiteAttackers[0].Column - 1) == false)
                            {
                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, whiteAttackers[0], whiteAttackers[0].Row - 1, whiteAttackers[0].Column - 1);
                            }
                            break;
                        }
                    }
                    else if (whiteAttackers[0].Row - bk.Row == 2)
                    {
                        if (whiteAttackers[0].Column - bk.Column == 1)
                        {
                            if (Defence.CheckPat(boardObj, whiteAttackers[0], whiteAttackers[0].Row - 1, whiteAttackers[0].Column + 1) == false)
                            {
                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, whiteAttackers[0], whiteAttackers[0].Row - 1, whiteAttackers[0].Column + 1);

                            }
                            break;

                        }
                        else if (whiteAttackers[0].Column - bk.Column == -1)
                        {
                            if (Defence.CheckPat(boardObj, whiteAttackers[0], whiteAttackers[0].Row - 1, whiteAttackers[0].Column - 1) == false)
                            {
                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, whiteAttackers[0], whiteAttackers[0].Row - 1, whiteAttackers[0].Column - 1);
                            }
                            break;
                        }
                        else if (whiteAttackers[0].Column - bk.Column > 1)
                        {
                            if (Defence.CheckPat(boardObj, whiteAttackers[0], whiteAttackers[0].Row, bk.Column + 1) == false)
                            {
                               boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, whiteAttackers[0], whiteAttackers[0].Row, bk.Column + 1);
                            }
                            break;

                        }
                        else if (whiteAttackers[0].Column - bk.Column <1)
                        {
                            if (Defence.CheckPat(boardObj, whiteAttackers[0], whiteAttackers[0].Row, bk.Column - 1) == false)
                            {
                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, whiteAttackers[0], whiteAttackers[0].Row, bk.Column - 1);

                            }
                            break;
                        }
                    }
                    else if (whiteAttackers[0].Row - bk.Row == 1)
                    {
                        if (whiteAttackers[0].Column - bk.Column == 2)
                        {
                            if (Defence.CheckPat(boardObj, whiteAttackers[0], whiteAttackers[0].Row + 1, whiteAttackers[0].Column - 1) == false)
                            {

                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, whiteAttackers[0], whiteAttackers[0].Row + 1, whiteAttackers[0].Column - 1);
                            }
                        }
                        else if (whiteAttackers[0].Column - bk.Column == -2)
                        {
                            if (Defence.CheckPat(boardObj, whiteAttackers[0], whiteAttackers[0].Row + 1, whiteAttackers[0].Column + 1) == false)
                            {

                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, whiteAttackers[0], whiteAttackers[0].Row + 1, whiteAttackers[0].Column + 1);
                            }
                            break;
                        }
                        else if (whiteAttackers[0].Column - bk.Column > 2)
                        {
                            if (Defence.CheckPat(boardObj, whiteAttackers[0], whiteAttackers[0].Row, bk.Column + 2) == false)
                            {

                            boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, whiteAttackers[0], whiteAttackers[0].Row, bk.Column + 2);
                            }
                            break;
                        }
                        else if (whiteAttackers[0].Column - bk.Column < -2)
                        {
                            if (Defence.CheckPat(boardObj, whiteAttackers[0], whiteAttackers[0].Row, bk.Column - 2) == false)
                            {
                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, whiteAttackers[0], whiteAttackers[0].Row, bk.Column - 2);
                            }
                            break;
                        }
                    }

                    break;
                }
            case "lower":
                {
                    if (whiteAttackers[0].Row - bk.Row == -2)
                    {
                        coordinate = bk.Row - 1;
                        boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                    }
                    else //whiteAttackers[0].Row -bk.Row==-1
                    {
                        if (whiteAttackers[0].Column - bk.Column == 3)
                        {
                            coordinate = whiteAttackers[0].Column - 1;
                            boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                            break;
                        }
                        else if (whiteAttackers[0].Column - bk.Column == -3)
                        {
                            coordinate = whiteAttackers[0].Column + 1;
                            boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                            break;
                        }
                        else if (whiteAttackers[0].Column - bk.Column == 2)
                        {
                            coordinate = whiteAttackers[0].Column - 1;
                            boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                            break;
                        }
                        else if (whiteAttackers[0].Column - bk.Column == -2)
                        {
                            coordinate = whiteAttackers[0].Column + 1;
                            boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                            break;
                        }
                        coordinate = bk.Row - 1;
                    }
                    boardObj = HorizontalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                    break;
                }
            case "left":
                {
                    if (whiteAttackers[0].Column - bk.Column == -1)
                    {
                        coordinate = bk.Column;
                    }
                    else
                    {
                        coordinate = bk.Row - 1;
                    }
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                    break;
                }
            case "right":
                {
                    if (whiteAttackers[0].Column - bk.Column == 1)
                    {
                        coordinate = bk.Column;
                    }
                    else
                    {
                        coordinate = bk.Row + 1;
                    }
                    boardObj = VerticalSegmentation(boardObj, coordinate, whiteAttackers, 1);
                    break;
                }

        }
        EndGame.StepUpdate(whiteAttackers, boardObj.Figures[1]);
        return boardObj;
    }
    /// <summary>
    /// Devides the board in two base don the kings' positions. For upper & lower segmentation.
    /// </summary>
    /// <param name="boardObj">Board type object.</param>
    /// <returns>Returns Board type object to update the chess board.</returns>
    public static Board HorizontalSegmentation(Board boardObj, int coordinate, List<IFigure> whiteAttackers, int index1)
    {
        //
        foreach (IFigure _figure in whiteAttackers)
        {
            //checks if any item in the list/figure has already done a step, it is deleted from the list
            //and edded in the end
            if (_figure.Row == coordinate)
            {
                //update 
                EndGame.StepUpdate(whiteAttackers, _figure);

                //run new endgame with the updated list
                EndGame endgame = new EndGame(boardObj, whiteAttackers);
                boardObj = endgame.RunEndgame01(boardObj, whiteAttackers);
                return boardObj;
            }
        }

        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        bool shouldBreak = false;

        //
        int index = 0;

        foreach (IFigure figure in whiteAttackers)
        {
            if (index != index1)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (boardObj.BoardWithFiguresSteps[coordinate, i] != null &&
                        boardObj.BoardWithFiguresSteps[coordinate, i].Contains(figure.StepSymbol) &&
                         boardObj.BoardWithFiguresSteps[coordinate, i].All(c => !char.IsLetter(c)))
                    {
                        if (Math.Abs(bk.Column - i) > 1)
                        {
                            if (Defence.CheckPat(boardObj, figure, coordinate, i) == false)
                            {
                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, figure, coordinate, i);
                                switch (figure.Name)
                                {
                                    case "b":
                                        EndGame.StepUpdate(whiteAttackers, boardObj.Figures[1]);
                                        break;
                                    case "c":
                                        EndGame.StepUpdate(whiteAttackers, boardObj.Figures[2]);
                                        break;
                                    case "d":
                                        EndGame.StepUpdate(whiteAttackers, boardObj.Figures[3]);
                                        break;
                                }
                                shouldBreak = true;
                                //break;

                                return boardObj;
                            }
                        }
                    }
                }
                index++;
            }
            else
            {
                (Board updatedBoardObj, bool success) = Improvements.ImprovePositionHorizontal(boardObj, whiteAttackers[0]);
                if (success)
                {
                    boardObj = updatedBoardObj;
                }
                else
                {
                    (Board updatedBoardObj2, bool success2) = Improvements.ImprovePositonVertical(boardObj, whiteAttackers[0]);
                }
                shouldBreak = true;
            }
            if (shouldBreak)
                break;
        }
        return boardObj;
    }
    /// <summary>
    /// Devides the board in two base don the kings' positions. For left & right segmentation.
    /// </summary>
    /// <param name="boardObj">Board type object.</param>
    /// <returns>Returns Board type object to update the chess board.</returns>
    public static Board VerticalSegmentation(Board boardObj, int coordinate, List<IFigure> whiteAttackers, int index1)
    {
        foreach (IFigure _figure in whiteAttackers)
        {
            //checks if any item in the list/figure has already done a step, it is deleted from the list
            //and edded in the end
            if (_figure.Column == coordinate)
            {
                //update 
                EndGame.StepUpdate(whiteAttackers, _figure);

                //run new endgame with the updated list
                EndGame endgame = new EndGame(boardObj, whiteAttackers);
                boardObj = endgame.RunEndgame01(boardObj, whiteAttackers);
                return boardObj;
            }
        }

        //HARD CODE
        IFigure bk = boardObj.Figures[4];
        bool shouldBreak = false;

        int index = 0;

        foreach (IFigure figure in whiteAttackers)
        {
            if (index != index1)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (boardObj.BoardWithFiguresSteps[i, coordinate] != null &&
                           boardObj.BoardWithFiguresSteps[i, coordinate].Contains(figure.StepSymbol) &&
                            boardObj.BoardWithFiguresSteps[i, coordinate].All(c => !char.IsLetter(c)))
                    {
                        if (Math.Abs(bk.Row - i) > 1)
                        {
                            if (Defence.CheckPat(boardObj, figure, i, coordinate) == false)
                            {
                                boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, figure, i, coordinate);//
                                switch (figure.Name)
                                {
                                    case "b":
                                        EndGame.StepUpdate(whiteAttackers, boardObj.Figures[1]);
                                        break;
                                    case "c":
                                        EndGame.StepUpdate(whiteAttackers, boardObj.Figures[2]);
                                        break;
                                    case "d":
                                        EndGame.StepUpdate(whiteAttackers, boardObj.Figures[3]);
                                        break;
                                }
                                shouldBreak = true;
                                //break;

                                return boardObj;
                            }
                        }
                    }
                }
                index++;
            }
            else
            {
                (Board updatedBoardObj, bool success) = Improvements.ImprovePositonVertical(boardObj, whiteAttackers[0]);
                if (success)
                {
                    boardObj = updatedBoardObj;
                }
                else
                {
                    (Board updatedBoardObj2, bool success2) = Improvements.ImprovePositionHorizontal(boardObj, whiteAttackers[0]);

                }
                shouldBreak = true;
            }
            if (shouldBreak)
                break;
        }
        return boardObj;
    }
}