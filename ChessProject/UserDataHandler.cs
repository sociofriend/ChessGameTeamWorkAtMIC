using System.Diagnostics;
using ChessLibrary;

        //write figure names on <BoardWithFiguresSteps> by user input coordinates
        for (int i = 0; i <= 3; i++)
            if (i != 3)
            {
                Board.WriteLegalStepsOnBoard(figures[i], BoardWithFiguresSteps);
            }
        }
            {
                Board.WriteLegalStepsOnBoard(figures[i], BoardWithFiguresSteps);
            }

        //write figure names on <BoardWithFiguresSteps> by user input coordinates
        for (int i = 0; i <= 3; i++)
            if (i != 3 && i != 2)
            {
                Board.WriteLegalStepsOnBoard(figures[i], BoardWithFiguresSteps);
            }
        }
            {
                Board.WriteLegalStepsOnBoard(figures[i], BoardWithFiguresSteps);
            }

        //White Rook 2 doesn't exist 

        Rook r2 = new Rook();
        figures[3] = r2;

        //White Rook 1  doesn't exist 
        Rook r1 = new Rook();       
        //White Rook 2 doesn't exist 
        Rook r2 = new Rook();
        figures[3] = r2;