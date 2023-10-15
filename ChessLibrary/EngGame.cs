using System;
using System.Diagnostics;
using ChessLibrary.GameFigures;
using static ChessLibrary.Defence;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ChessLibrary;
public class EndGame
{
    public static int step = 1;
    //refactor.
    string Segment { get; set; }

    List<IFigure> RooksToDefend { get; set; }
    Board BoardObj { get; set; }

    List<IFigure> WhiteAttackers { get; set; }


    public EndGame(Board boardObj, List<IFigure> whiteAttackers)
    {
        Segment = Board.IdentifySegment(boardObj);

        //local variable referring to black king respective object in Figures array of respective Board object(argument)
        IFigure bk = boardObj.Figures[4];

        //a list of IFigure type objects to add the rooks needing protection from black king
        RooksToDefend = CheckRooks(boardObj.Figures, boardObj.BoardWithFiguresSteps);

        BoardObj = boardObj;
        WhiteAttackers = whiteAttackers;

        //boardObj = RunEndgame01(boardObj, whiteAttackers);/////

    }

    public Board RunEndgame01(Board boardObj, List<IFigure> whiteAttackers)
    {
        //if rook is under attack by black king, changes rook position.
        if (RooksToDefend.Count > 0)
        {
            boardObj = RunRookDefence(boardObj, RooksToDefend);
        }
        else            //if rooks are not under attack, run attack steps.
        {
            //switch case will use "step" local variable with default value equal to 1
            switch (step)
            {
                //first level attack - cuttin black king segment(horizontally or vertically)
                case 1:
                    boardObj = Attack.FirstAttackBySegment(boardObj, Segment, whiteAttackers);
                    break;
                case 2:
                    if (Segment == "upper" || Segment == "lower")
                    {
                        if (boardObj.Figures[4].Row != 0 && boardObj.Figures[4].Row != 7)
                        {
                            boardObj = Attack.SecondAttackBySegment(boardObj, Segment, whiteAttackers);
                        }
                        else
                        {
                            boardObj = Attack.ThirdAttackBySegment(boardObj, Segment, whiteAttackers);
                        }
                    }
                    else  //left right
                    {
                        if (boardObj.Figures[4].Column != 0 && boardObj.Figures[4].Column != 7)
                        {
                            boardObj = Attack.SecondAttackBySegment(boardObj, Segment, whiteAttackers);
                        }
                        else
                        {
                            boardObj = Attack.ThirdAttackBySegment(boardObj, Segment, whiteAttackers);
                        }
                    }
                    break;
                case 3:
                    boardObj = Attack.ThirdAttackBySegment(boardObj, Segment, whiteAttackers);
                    break;
                case 4:
                    boardObj = Attack.FourthAttackBySegment(boardObj, Segment, whiteAttackers);
                    break;
                default:
                    boardObj = Attack.FourthAttackBySegment(boardObj, Segment, whiteAttackers);
                    break;
            }
        }

        return boardObj;
    }
    public Board RunEndgame02(Board boardObj, List<IFigure> whiteAttackers)
    {
        //if rook is under attack by black king, changes rook position.
        if (RooksToDefend.Count > 0)
        {
            boardObj = RunRookDefence(boardObj, RooksToDefend);
        }
        else            //if rooks are not under attack, run attack steps.
        {
            //switch case will use "step" local variable with default value equal to 1
            switch (step)
            {
                //first level attack - cuttin black king segment(horizontally or vertically)
                case 1:
                    boardObj = Attack.FirstAttackBySegment(boardObj, Segment, whiteAttackers);
                    break;
                default:
                    boardObj = Attack.Attack02(boardObj, Segment, whiteAttackers);
                    break;
            }
        }
        return boardObj;
    }
    public Board RunEndgame03(Board boardObj, List<IFigure> whiteAttackers)
    {
        //if rook is under attack by black king, changes rook position.
        if (RooksToDefend.Count > 0)
        {
            boardObj = RunRookDefence(boardObj, RooksToDefend);
        }
        else            //if rooks are not under attack, run attack steps.
        {
            //switch case will use "step" local variable with default value equal to 1
            switch (step)
            {
                //first level attack - cuttin black king segment(horizontally or vertically)
                case 1:
                    boardObj = Attack.FirstAttackBySegment(boardObj, Segment, whiteAttackers);
                    break;
                default:
                    boardObj = Attack.Attack03(boardObj, Segment, whiteAttackers);
                    break;
            }
        }
        return boardObj;
    }

    public static void StepUpdate(List<IFigure> whiteAttackers, IFigure figureShiftToEnd)
    {
        int deleteindex = 0;

        foreach (IFigure figure in whiteAttackers)
        {
            if (figure.Name == figureShiftToEnd.Name)
            {
                whiteAttackers.RemoveAt(deleteindex);
                break;
            }
            else
            {
                deleteindex++;
            }

        }
        whiteAttackers.Add(figureShiftToEnd);
        step++;
    }


    //public static void StepUpdate1(List<IFigure> whiteAttackers, IFigure figureShiftToEnd)
    //{
    //    step++;
    //    whiteAttackers.RemoveAt(0);
    //    whiteAttackers.Add(figureShiftToEnd);
    //}
}

