namespace ChessLibrary.GameFigures;


    #region Properties
    public string AlgebraicNotation { get; set; }













    #endregion
    /// <summary>
    /// <summary>
        //row change -> step up 
        while (row >= 0)
                //Board.FigureNames.Contains(board[row, column][0].ToString()))
                board[row, column].Any(x => char.IsLetter(x)) &&
            {
        //row change -> step down
        while (row < 8)
//Board.FigureNames.Contains(board[row, column][0].ToString()))
                board[row, column].Any(x => char.IsLetter(x)) &&
            {
            else if (board[row, column] == null || board[row, column].Contains("e"))
            {
                board[row, column] = StepSymbol;
                row++;
            }

        }
        //column change -> step left
        while (column >= 0)
//Board.FigureNames.Contains(board[row, column][0].ToString()))
  board[row, column].Any(x => char.IsLetter(x)) &&
            {
        //column change -> step right
        while (column < 8)
                //Board.FigureNames.Contains(board[row, column][0].ToString()))
                board[row, column].Any(x => char.IsLetter(x)) &&
                 !board[row, column].Contains("e")) //LINQ --Any
            {
                board[row, column] += StepSymbol;
                column = 8;
                break;
            }
            else if (board[row, column] == null|| board[row, column].Contains("e") )
            {
                board[row, column] = StepSymbol;
                column++;
            }
            else if (board[row, column] != null || board[row, column].Contains("e"))
            {
                board[row, column] += StepSymbol;
                column++;
            }
          
        }


    /// <summary>
    /// Check whether the field of defend-needing figure field contains the step symbol of attacking figure
    /// </summary>
    /// <param name="attacker">Attacking figure object.</param>
    /// <param name="defender">Figure to be checked for attack of attacker.</param>
    /// <param name="board">Board type object representing chess board and everything related to it.</param>
    /// <returns>Returns boolean type value.</returns>

    //the following mehtods of IFigure interface will be implemented upon need
    public bool IsProtected(Board boardObj, IFigure protectable)