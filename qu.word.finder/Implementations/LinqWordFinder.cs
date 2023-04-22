using Ardalis.GuardClauses;
using qu.word.finder.Extensions;
using qu.word.finder.Interfaces;

namespace qu.word.finder;

/// <summary>
/// I used this approach as the easy way, but maybe not the best since some actions could be more expensive using the memory
/// as first need to get all the lines vertical/horizontal and them execute some search and filters to count the number of words found
/// and order in descending way to get the top 10. However, this could be good approach when the wordstreem is a short list.
/// </summary>
public class LinqWordFinder : IWordFinder
{
    private readonly string[] _matrix;
    private readonly int _topCount;

    public LinqWordFinder(IEnumerable<string> matrix, int topCount)
    {
        Guard.Against.Null(matrix);
        
        _matrix = matrix.Select(item=> item.ToLower()).ToArray();
        _matrix.ValidMatrix();
        
        _topCount = topCount;
    }
    
    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        //Get all the lines vertical and horizontal from the matrix.
        var lines = _matrix.GetAllLines();
        
        return wordstream
            //First delete duplicate items
            .Distinct()
            //Get word with counts
            .Select(word =>
            {
                var lowerWord = word.ToLower();
                return (
                    Word: lowerWord,
                    Count: lines.Sum(line => line.GetFrecuency(lowerWord))
                );
            })
            //Filter word not founds
            .Where(item => item.Count > 0)
            //Then order by count
            .OrderByDescending(item => item.Count)
            //Take the top 10
            .Take(_topCount)
            //Return just the words without count
            .Select(item => item.Word);
    }
}