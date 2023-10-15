namespace ChessLibrary.GameFigures;

public interface IFigure
{
    public string AlgebraicNotation { get; set; }
    public string Name { get; set; }
    public int[,] Coordinates { get; set; }
    public string [,] LegalSteps { get; set; }
    public int FigureNumber { get; set; }
    public string FigureNumberString { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public string StepSymbol { get; set; }
    public List<int> TwoDigitSteps { get; set; }


    //add legal steps of a figure on the chess board related to Board object
    public void AddLegalSteps(string[,] board);

    //check if a figure is protected, aka whether the field contains step symbols of other white figures
    public bool IsProtected(Board boardObj, IFigure protectable);

    //check whether the field of defend-needing figure field contains the step symbol of attacking figure
    public bool FigureUnderAttack(IFigure figure, IFigure figure1, string[,] board);

    //check whether a figure has valid legal step(at least one). e.g. for black king this will mean only BK step symbol(e.g. "5") on
    //some filed, or white figure name and bk step symbol ("c5")
    public bool HasLegalSteps(Board boardObj, IFigure figure);

    //check a figure being under attack, akafigure's field contains a step symbol of opposite color figure.
    public bool IsUnderAttack(Board boardObj, IFigure figure);
}