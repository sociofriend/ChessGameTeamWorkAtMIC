using ChessLibrary;namespace ChessLibrary.GameFigures;public class Queen : IFigure{    public string AlgebraicNotation { get; set; }    public string Name { get; set; }    public int[,] Coordinates { get; set; }    public string[,] LegalSteps { get; set; } = new string[8, 8];    public int FigureNumber { get; set; }    public string FigureNumberString { get; set; }    public int Row { get; set; }    public int Column { get; set; }    public string StepSymbol { get; set; }    public List<int> TwoDigitSteps { get; set; } = new List<int>();

    /// <summary>    /// Parameterised constructor initialises all local fields.    /// </summary>    /// <param name="coordinatesInput">Integer type two-dimensional array carrying data    /// input for figure position.</param>    public Queen(int[,] coordinatesInput)    {        Coordinates coordinatesObj = new Coordinates(coordinatesInput);        Coordinates = coordinatesInput;        FigureNumber = coordinatesObj.FigureNumber;        FigureNumberString = coordinatesObj.FigureNumberString;        Row = coordinatesObj.Row;        Column = coordinatesObj.Column;        Name = "b";        StepSymbol = "2";    }

    /// <summary>    /// Adds legal steps of the White Queen to the board in 8 directions.    /// </summary>    /// <param name="board">String type two-dimensional array.</param>    public void AddLegalSteps(string[,] board)    {        int row = Row - 1;        int column = Column;
        //row change -> step up 
        while (row >= 0)        {            if (board[row, column] != null &&
                //Board.FigureNames.Contains(board[row, column][0].ToString())
                board[row, column].Any(x => char.IsLetter(x)) &&                !board[row, column].Contains("e")) //LINQ --Any
            {                    board[row, column] += StepSymbol;                    row = -1;                    break;                }            else if (board[row, column] == null || board[row, column].Contains("e"))            {                board[row, column] = StepSymbol;                row--;            }            else if (board[row, column] != null || board[row, column].Contains("e"))
            {                board[row, column] += StepSymbol;                row--;            }        }

        row = Row + 1;        column = Column;
        //row change -> step down
        while (row < 8)        {            if (board[row, column] != null &&                //Board.FigureNames.Contains(board[row, column][0].ToString()))                board[row, column].Any(x => char.IsLetter(x)) &&                !board[row, column].Contains("e")) //LINQ --Any
            {                    board[row, column] += StepSymbol;                    row = 8;                    break;                }            else if (board[row, column] == null || board[row, column].Contains("e"))            {                board[row, column] = StepSymbol;                row++;            }            else if (board[row, column] != null || board[row, column].Contains("e"))            {                board[row, column] += StepSymbol;                row++;            }        }        column = Column - 1;        row = Row;
        //column change -> step left
        while (column >= 0)        {            if (board[row, column] != null &&                //Board.FigureNames.Contains(board[row, column][0].ToString()))                board[row, column].Any(x => char.IsLetter(x)) &&                !board[row, column].Contains("e")) //LINQ --Any
            {                board[row, column] += StepSymbol;                column = 0;                break;            }            else if (board[row, column] == null || board[row, column].Contains("e"))            {                board[row, column] = StepSymbol;                column--;            }            else if (board[row, column] != null || board[row, column].Contains("e"))            {                board[row, column] += StepSymbol;                column--;            }        }

        column = Column + 1;        row = Row;
        //column change -> step right
        while (column < 8)        {            if (board[row, column] != null &&                //Board.FigureNames.Contains(board[row, column][0].ToString()))                board[row, column].Any(x => char.IsLetter(x)) &&                !board[row, column].Contains("e")) //LINQ --Any
            {                board[row, column] += StepSymbol;                column = 8;                break;            }            else if (board[row, column] == null || board[row, column].Contains("e"))            {                board[row, column] = StepSymbol;                column++;            }            else if (board[row, column] != null || board[row, column].Contains("e"))            {                board[row, column] += StepSymbol;                column++;            }        }

        row = Row - 1;        column = Column - 1;
        //diagonally left and up
        while (row >= 0 && column >= 0)        {            if (board[row, column] != null &&                //Board.FigureNames.Contains(board[row, column][0].ToString()))                board[row, column].Any(x => char.IsLetter(x)) &&                !board[row, column].Contains("e")) //LINQ --Any
            {                board[row, column] += StepSymbol;                row = 0;                break;            }            else if (board[row, column] == null || board[row, column].Contains("e"))            {                board[row, column] = StepSymbol;                row--;                column--;            }            else if (board[row, column] != null || board[row, column].Contains("e"))            {                board[row, column] += StepSymbol;                row--;                column--;            }        }

        row = Row + 1;        column = Column + 1;
        //diagonally right and down
        while (row < 8 && column < 8)        {            if (board[row, column] != null &&                //Board.FigureNames.Contains(board[row, column][0].ToString()))                board[row, column].Any(x => char.IsLetter(x)) &&                !board[row, column].Contains("e")) //LINQ --Any
            {                board[row, column] += StepSymbol;                row = 8;                break;            }            else if (board[row, column] == null || board[row, column].Contains("e"))            {                board[row, column] = StepSymbol;                row++;                column++;            }            else if (board[row, column] != null || board[row, column].Contains("e"))            {                board[row, column] += StepSymbol;                row++;                column++;            }        }

        row = Row - 1;        column = Column + 1;
        //diagonally right and up
        while (row >= 0 && column < 8)        {            if (board[row, column] != null &&                //Board.FigureNames.Contains(board[row, column][0].ToString()))                board[row, column].Any(x => char.IsLetter(x)) &&                !board[row, column].Contains("e")) //LINQ --Any
            {                board[row, column] += StepSymbol;                row = 0;                break;            }            else if (board[row, column] == null || board[row, column].Contains("e"))            {                board[row, column] = StepSymbol;                row--;                column++;            }            else if (board[row, column] != null || board[row, column].Contains("e"))            {                board[row, column] += StepSymbol;                row--;                column++;            }                    }

        row = Row + 1;        column = Column - 1;
        //diagonally left and down
        while (row < 8 && column >= 0)        {            if (board[row, column] != null &&                //Board.FigureNames.Contains(board[row, column][0].ToString()))                board[row, column].Any(x => char.IsLetter(x)) &&                !board[row, column].Contains("e")) //LINQ --Any
            {                board[row, column] += StepSymbol;                row = 8;                break;            }            else if (board[row, column] == null || board[row, column].Contains("e"))            {                board[row, column] = StepSymbol;                row++;                column--;            }            else if (board[row, column] != null || board[row, column].Contains("e"))            {                board[row, column] += StepSymbol;                row++;                column--;            }        }    }

    //collects figure's legal steps as two-digit integers into list
    public List<int> LegalStepsToArray(Board boardObj, IFigure queen)    {        for (int i = 0; i < 8; i++)        {            for (int j = 0; j < 8; j++)            {                if (boardObj.BoardWithFiguresSteps[i, j].Contains(queen.StepSymbol))                {                    queen.TwoDigitSteps.Add(ChessLibrary.Coordinates.ConvertCoordinatesToNumber(i, j));                }            }        }        return queen.TwoDigitSteps;    }

    //the following mehtods of IFigure interface will be implemented upon need
    public bool IsProtected(Board boardObj, IFigure protectable)    {        return true;    }        public bool FigureUnderAttack(IFigure figure, IFigure figure1, string[,] board)    {        return true;    }        public bool HasLegalSteps(Board boardObj, IFigure figure)    {        return false;    }    public bool IsUnderAttack(Board boardObj, IFigure figure)    {        return false;    }}