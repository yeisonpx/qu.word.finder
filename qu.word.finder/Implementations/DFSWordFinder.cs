using Ardalis.GuardClauses;
using qu.word.finder.Extensions;
using qu.word.finder.Interfaces;

namespace qu.word.finder;

/// <summary>
/// Using Deep First Search approach iterate each row and column looking for the firs letter of the word search when is found
/// continue checking row and column until get a full match.
/// This approach seems to be good for small word list but maybe no the best for large stream.
/// </summary>
public class DFSWordFinder: IWordFinder
{
    private readonly string[] _matrix;
    private readonly int _topCount;

    public DFSWordFinder(IEnumerable<string> matrix, int topCount)
    {       
        Guard.Against.Null(matrix);
        
        _matrix = matrix.Select(item=> item.ToLower()).ToArray();
        _matrix.ValidMatrix();
        
        _topCount = topCount;

    }
    
    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        var rows = _matrix;
        var lineLength = rows[0].Length;
        
        var result = new Dictionary<string, int>();

        foreach (var word in wordstream)
        {
            var lowerWord = word.ToLower();
            var firstLetter = lowerWord[0];
            var count = 0;
            for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
            {
                var row = rows[rowIndex];
                for (var columnIndex = 0; columnIndex < lineLength; columnIndex++)
                {
                    if (row[columnIndex] == firstLetter && IsWordFound(lowerWord, 0, rowIndex, columnIndex, true, true))
                        count++;
                }
            }
            
            if(count>0) 
                result.TryAdd(lowerWord, count);
        }

        return result
            .OrderByDescending(item => item.Value)
            .Take(_topCount)
            .Select(item => item.Key);
    }

    private bool IsWordFound(string word, int wordIndex, int rowIndex, int columIndex, bool checkRow, bool checkColumn)
    {
        if (wordIndex == word.Length)
            return true;

        if (rowIndex < 0 || columIndex < 0 || rowIndex >= _matrix.Length || columIndex >= _matrix[0].Length || _matrix[rowIndex][columIndex] != word[wordIndex])
            return false;

        if (checkRow && !checkColumn)
            return IsWordFound(word, wordIndex + 1, rowIndex, columIndex + 1, true, false);
        
        if (!checkRow && checkColumn)
            return IsWordFound(word, wordIndex + 1, rowIndex + 1, columIndex, false,true);
        
        return IsWordFound(word, wordIndex + 1, rowIndex, columIndex + 1, true, false) ||
               IsWordFound(word, wordIndex + 1, rowIndex + 1, columIndex, false,true);
    }
}