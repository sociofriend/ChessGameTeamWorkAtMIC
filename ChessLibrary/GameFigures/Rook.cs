namespace ChessLibrary.GameFigures;public class Rook : IFigure{


    #region Properties
    public string AlgebraicNotation { get; set; }    public string Name { get; set; }    public int[,] Coordinates { get; set; }    public string[,] LegalSteps { get; set; } = new string[8, 8];    public int FigureNumber { get; set; }    public string FigureNumberString { get; set; }    public int Row { get; set; }    public int Column { get; set; }    public string StepSymbol { get; set; }    public List<int> TwoDigitSteps { get; set; }













    #endregion
    /// <summary>    /// Parameterised constructor initialises all local fields.    /// </summary>    /// <param name="coordinatesInput">Integer type two-dimensional array carrying data    /// input for figure position.</param>    ///     public Rook(){    }public Rook(int[,] coordinatesInput, string name)    {        Coordinates coordinatesObj = new Coordinates(coordinatesInput);        Coordinates = coordinatesInput;        FigureNumber = coordinatesObj.FigureNumber;        FigureNumberString = coordinatesObj.FigureNumberString;        Row = coordinatesObj.Row;        Column = coordinatesObj.Column;        if (name == "1")        {            Name = "c";            StepSymbol = "3";        }        else if (name == "2")        {            Name = "d";            StepSymbol = "4";        }    }
    /// <summary>    /// Adds legal steps of the White Rook to the board in 8 directions.    /// If next coordinate is not null, the loop breaks, to avoid re-writing other figures.    /// </summary>    /// <param name="board">String type two-dimensional array.</param>    public void AddLegalSteps(string[,] board)    {        int row = Row - 1;        int column = Column;
        //row change -> step up 
        while (row >= 0)        {            if (board[row, column] != null &&
                //Board.FigureNames.Contains(board[row, column][0].ToString()))
                board[row, column].Any(x => char.IsLetter(x)) &&                !board[row, column].Contains("e")) //LINQ --Any
            {                board[row, column] += StepSymbol;                row = -1;                break;            }            else if (board[row, column] == null || board[row, column].Contains("e"))            {                board[row, column] = StepSymbol;                row--;            }            else if (board[row, column] != null || board[row, column].Contains("e"))            {                board[row, column] += StepSymbol;                row--;            }        }        row = Row + 1;        column = Column;
        //row change -> step down
        while (row < 8)        {            if (board[row, column] != null &&
//Board.FigureNames.Contains(board[row, column][0].ToString()))
                board[row, column].Any(x => char.IsLetter(x)) &&                !board[row, column].Contains("e")) //LINQ --Any          //HARD CODE
            {                board[row, column] += StepSymbol;                row = 8;                break;            }
            else if (board[row, column] == null || board[row, column].Contains("e"))
            {
                board[row, column] = StepSymbol;
                row++;
            }            else if (board[row, column] != null || board[row, column].Contains("e"))            {                board[row, column] += StepSymbol;                row++;            }

        }        column = Column - 1;        row = Row;
        //column change -> step left
        while (column >= 0)        {            if (board[row, column] != null &&
//Board.FigureNames.Contains(board[row, column][0].ToString()))
  board[row, column].Any(x => char.IsLetter(x)) &&                !board[row, column].Contains("e")) //LINQ --Any
            {                board[row, column] += StepSymbol;                column = 0;                break;            }            else if (board[row, column] == null || board[row, column].Contains("e"))            {                board[row, column] = StepSymbol;                column--;            }            else if (board[row, column] != null || board[row, column].Contains("e"))            {                board[row, column] += StepSymbol;                column--;            }        }        column = Column + 1;        row = Row;
        //column change -> step right
        while (column < 8)        {            if (board[row, column] != null &&
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
          
        }    }


    /// <summary>
    /// Check whether the field of defend-needing figure field contains the step symbol of attacking figure
    /// </summary>
    /// <param name="attacker">Attacking figure object.</param>
    /// <param name="defender">Figure to be checked for attack of attacker.</param>
    /// <param name="board">Board type object representing chess board and everything related to it.</param>
    /// <returns>Returns boolean type value.</returns> public bool FigureUnderAttack(IFigure attacker, IFigure defender, string[,] board)    {        for (int i = 0; i < 8; i++)        {            for (int j = 0; j < 8; j++)            {                if (board[i, j] != null && board[i, j].Contains(attacker.StepSymbol))                {                    attacker.LegalSteps[i, j] = StepSymbol;                }            }        }        if (attacker.LegalSteps[defender.Row, defender.Column] != null)            return true;        else            return false;    }

    //the following mehtods of IFigure interface will be implemented upon need
    public bool IsProtected(Board boardObj, IFigure protectable)    {        return false;    }    public bool HasLegalSteps(Board boardObj, IFigure figure)    {        return false;    }    public bool IsUnderAttack(Board boardObj, IFigure figure)    {        return false;    }}