using Ardalis.GuardClauses;
using qu.word.finder.Extensions;
using qu.word.finder.Interfaces;

namespace qu.word.finder;
/// <summary>
/// This approach first cached the whole matrix in a Dictionary in order to reduce the time validating if the words are in the matrix
/// I consider this could be one the best approach when we are handling a huge list of words but taking in consideration that the matrix
/// is not bigger than 64x64.
/// </summary>
public class CachedWordFinder : IWordFinder
{
    private readonly string[] _matrix;
    private Dictionary<string, int> _cached;
    private readonly int _topCount;

    public CachedWordFinder(IEnumerable<string> matrix, int topCount)
    {
        Guard.Against.Null(matrix);
        
        _matrix = matrix.Select(item=> item.ToLower()).ToArray();
        _matrix.ValidMatrix();
        
        _topCount = topCount;
        _cached = new Dictionary<string, int>();
    }
    
    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        //First create a dictionary with the matrix. 
        this.InitCached();
        
        //Validate which words exist in the matrix and insert in the result dictionary.
        var result = new Dictionary<string, int>();
        foreach (var word in wordstream)
        {
            var key = word.ToLower();
            if (_cached.TryGetValue(key, out var count))
                result.TryAdd(key, count);
        }
        
        return result
            //Sort the items by Value(number of repetitions)
            .OrderByDescending(item => item.Value)
            //Take top 10
            .Take(_topCount)
            //Return just the words
            .Select(item => item.Key);
    }

    /// <summary>
    /// This method take each line in the matrix(vertical/horizontal) and split it in small chunks in order to create
    /// a dictionary that will work as an index that will improve the performance searching the words in the matrix.
    /// </summary>
    private void InitCached()
    {
        AddCached(_matrix);
        AddCached(_matrix.GetVerticalLines());
    }
    
    /// <summary>
    /// Take a list of lines and split it in small chunks to then add it in the dictionary.
    /// Also validate how many time each key is repeated.
    /// </summary>
    /// <param name="lines">
    /// Lines to be indexed in the cached dictionary
    /// </param>
    private void AddCached(string[] lines)
    {
        foreach (var line in lines)
        {
            AddCached(line, line.Length-1);
        }
    }

    /// <summary>
    /// Take a line split it in small chunks an add it in the dictionary.
    /// Also validate how many time each key is repeated.
    /// </summary>
    /// <param name="line">
    /// Line to be indexed in the cached dictionary
    /// </param>
    private void AddCached(string line, int size)
    {
        if (size == 0)
            return;
        
        var startIndex = 0;
        while (( startIndex + size) <= line.Length)
        {
            var slide = line.Substring(startIndex, size);
            if (!_cached.TryAdd(slide, 1))
                _cached[slide] = ++_cached[slide];

            startIndex++;
        }
        
        AddCached(line, size-1);
    }
        
}