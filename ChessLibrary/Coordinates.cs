namespace ChessLibrary;

public class Coordinates
{
    #region - Properties
   public int Row { get; set; }  
   public int Column { get; set; }  
   public int Sum { get; set; }  
   public int Dif { get; set; }  
   public int FigureNumber { get; set; } 
   public string FigureNumberString { get; set; }
   public int[,] LegalSteps { get; set; }

   #endregion

   // to preserve default constructor
   public Coordinates()
   {
      
   }
   
   /// <summary>
   /// Parameterized constructor to initialize local properties.
   /// </summary>
   /// <param name="coordinatesInput">User input for figure coordinates.</param>
   public Coordinates(int[,] coordinatesInput)
   {
      AssignValuesToLocalProperties(coordinatesInput);
      FigureNumber = ConvertCoordinatesToNumber(Row, Column);
      FigureNumberString = Convert.ToString(FigureNumber);
   }

   /// <summary>
   /// Initialises properties by assigning the respective values
   /// out of operations with coordinates.
   /// </summary>
   /// <param name="Coordinates">Int type two-dimensional array</param>
   public void AssignValuesToLocalProperties(int[,] Coordinates)
   {
      for (int i = 0; i < 8; i++)
      {
         for (int j = 0; j < 8; j++)
         {
            if (Coordinates[i, j] == 1)
            {
               Row = i;
               Column = j;
               Sum = i + j;
               Dif = i - j;
               FigureNumber = ConvertCoordinatesToNumber(i, j); // tanel figures
               FigureNumberString = ConvertCoordinatesToString(i, j);
            }
         }
      }
   }

   /// <summary>
   /// Creates a two-symbol integer from two one-symbol integers.
   /// </summary>
   /// <param name="i">Integer type variable.</param>
   /// <param name="j">Integer type variable.</param>
   /// <returns>Integer.</returns>
   public static int ConvertCoordinatesToNumber(int i, int j)
   {
     return int.Parse(string.Concat(i.ToString(), j.ToString()));
   }
   
   /// <summary>
   /// Creates a two-symbol string from two one-symbol integers.
   /// </summary>
   /// <param name="i"></param>
   /// <param name="j"></param>
   /// <returns></returns>
   public static string ConvertCoordinatesToString(int i, int j)
   {
      return string.Concat(i.ToString(), j.ToString());
   }

   /// <summary>
   /// Generates two-dimensional array out of string input of Figure
   /// </summary>
   /// <param name="i">int type argument</param>
   /// <param name="j">int type argument</param>
   /// <returns>Returns two-dimensional array</returns>
   public static int[,] Create2DArrayByCoordinates(int i, int j)
   {
      int[,] coordinates = new int[8, 8];
      coordinates[i, j] = 1;
      return coordinates;
   }
   
}