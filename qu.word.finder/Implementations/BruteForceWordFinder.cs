using Ardalis.GuardClauses;
using qu.word.finder.Extensions;
using qu.word.finder.Interfaces;

namespace qu.word.finder;

/// <summary>
/// Brute force is the simplest way to test iterating over each row and column and check this approach to validate the different
/// in the performance. Just included to test I do not consider that could be good solution for this challenge.
/// </summary>
public class BruteForceWordFinder : IWordFinder
{
    private readonly string[] _matrix;
    private readonly int _topCount;

    public BruteForceWordFinder(IEnumerable<string> matrix, int topCount)
    {
        Guard.Against.Null(matrix);
        
        _matrix = matrix.Select(item => item.ToLower()).ToArray();
        _matrix.ValidMatrix();
        
        _topCount = topCount;
    }
    
    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        var result = new Dictionary<string, int>();
        //First vertical and horizontal lines of the matrix.
        var lines = _matrix.GetAllLines();
        
        foreach (var word in wordstream)
        {
            var count = 0;
            var lowerWord = word.ToLower();
            
            foreach (var line in lines)
            {
                var frequency = line.GetFrecuency(lowerWord);
                if (frequency>0)
                    count+= frequency;
            }

            if(count>0)
                result.TryAdd(lowerWord, count);
        }

        return result.OrderByDescending(item => item.Value)
            .Take(_topCount)
            .Select(item => item.Key);
    }
}