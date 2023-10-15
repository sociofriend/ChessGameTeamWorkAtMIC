using ChessLibrary.GameFigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLibrary;


namespace ChessLibrary;

public class Improvements
{
    public static (Board boardObj, bool success) ImprovePositionHorizontal(Board boardObj, IFigure figure )
    {
        bool success = false;
        IFigure bk = boardObj.Figures[4];
        
        if (bk.Column <= 3)
        {
            for (int i = 7; i > 3; i--)
            {
                if (boardObj.BoardWithFiguresSteps[figure.Row, i].Contains(figure.StepSymbol) &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("a") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("b") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("c") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("d"))
                {
                        boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, figure, figure.Row, i);
                    success = true;
                        break;
                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (boardObj.BoardWithFiguresSteps[figure.Row, i].Contains(figure.StepSymbol) &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("a") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("b") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("c") &&
                    !boardObj.BoardWithFiguresSteps[figure.Row, i].Contains("d"))
                {
                    boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, figure, figure.Row, i);
                    success = true;
                    break;
                }
            }
        }
        return (boardObj, success);
    }
    public static (Board boardObj, bool success) ImprovePositonVertical(Board boardObj, IFigure figure)
    {
        IFigure bk = boardObj.Figures[4];
        bool success = false;
        if (bk.Row <= 3)
        {
            for (int i = 7; i > 3; i--)
            {
                if (boardObj.BoardWithFiguresSteps[i,figure.Column].Contains(figure.StepSymbol) &&
                    !boardObj.BoardWithFiguresSteps[i,figure.Column].Contains("a") &&
                    !boardObj.BoardWithFiguresSteps[i,figure.Column].Contains("b") &&
                    !boardObj.BoardWithFiguresSteps[i,figure.Column].Contains("c") &&
                    !boardObj.BoardWithFiguresSteps[i, figure.Column].Contains("d"))
                {
                    boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, figure, i, figure.Column);
                    success = true;
                    break;
                }

            }       
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (boardObj.BoardWithFiguresSteps[i, figure.Column].Contains(figure.StepSymbol) &&
                    !boardObj.BoardWithFiguresSteps[i, figure.Column].Contains("a") &&
                    !boardObj.BoardWithFiguresSteps[i, figure.Column].Contains("b") &&
                    !boardObj.BoardWithFiguresSteps[i, figure.Column].Contains("c") &&
                    !boardObj.BoardWithFiguresSteps[i, figure.Column].Contains("d"))
                {
                    boardObj = Board.UpdateBoard(boardObj, boardObj.Figures, figure, i, figure.Column);
                    success = true;
                    break;
                }
            }
        }
        return (boardObj, success);
    }
}
