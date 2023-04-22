using System.Text.RegularExpressions;

namespace qu.word.finder.Extensions;

public static class StringExtensions
{
    
    public static int GetFrecuency(this string line, string word) => Regex.Matches(line, word).Count;

    /// <summary>
    /// Get all the lines of the matrix taking vertical and horizontal lines an return as a single list.
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns>
    /// A list of lines
    /// </returns>
    public static IEnumerable<string> GetAllLines(this string[] matrix)
    {
        var lines = new List<string>();
        var verticalLines = GetVerticalLines(matrix);
        
        lines.AddRange(matrix);
        lines.AddRange(verticalLines);

        return lines;
    }

    /// <summary>
    /// Get the list of vertical lines of the matrix.
    /// </summary>
    /// <param name="lines"></param>
    /// <returns>List of lines corresponding to the vertical lines of the matrix</returns>
    public static string[] GetVerticalLines(this string[] lines)
    {
        var firstLine = lines.First();
        var horizontalLines = new string[firstLine.Length];
        for (var index = 0; index < firstLine.Length; index++)
        {
            var line = lines.Select(line => line[index]).ToArray();
            horizontalLines[index] = new string(line);
        }
        
        return horizontalLines;
    }
    
    public static void ValidMatrix(this string[] matrix)
    {
        bool isValidMatrix = matrix.Length > 64 && matrix.Length > 0 && matrix[0].Length > 64;
        if (isValidMatrix)
            throw new ArgumentException($"Matrix must be smaller than 64x64");
    }
}