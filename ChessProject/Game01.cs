namespace ChessProject;
using ChessLibrary;
using ChessLibrary.GameFigures;

using ChessLibrary;
public class Game01
{
    public void RunGame()
    {   
        //get user input for figures, create board object.
        Board boardObj = new Board(UserDataHandler.GetFigures01());
        List<IFigure> whiteAttackers = new List<IFigure>();
        whiteAttackers.Add(boardObj.Figures[1]);
        whiteAttackers.Add(boardObj.Figures[2]);
        whiteAttackers.Add(boardObj.Figures[3]);

        //runs the endgame while chack&mate is not achieved.
        while (Defence.CheckShakhAndMate(boardObj, boardObj.Figures[4]) == false)
        {
            //if black king is under attack, write a message 
            if (Defence.IsUnderShakh(boardObj, boardObj.Figures[4])) //BUG
                Console.WriteLine( "King is under attack !!!!!");

            //input BK new position and move on the board
            boardObj = new Board(UserDataHandler.MoveBlackKing(boardObj, whiteAttackers));
            Board.BoardPrinterForDebug(boardObj.BoardWithFiguresSteps);

            //pass the board object to endgame class, create an endgame object
            EndGame endgame = new EndGame(boardObj, whiteAttackers);
            boardObj = endgame.RunEndgame01(boardObj, whiteAttackers);
        }
        Console.WriteLine("Game is Over!!!");

    }
}