using qu.word.finder.Interfaces;

namespace qu.word.finder;

public class WordFinderFactory : IWordFinderFactory
{
    private readonly int _defaultTopCount = 10;

    public IWordFinder Get(FinderTypes type, IEnumerable<string> matrix)
    {
        switch (type)
        {
            case FinderTypes.Linq:
                return new LinqWordFinder(matrix, _defaultTopCount);
            case FinderTypes.BruteForce:
                return new BruteForceWordFinder(matrix, _defaultTopCount);
            case FinderTypes.CachedMatrix:
                return new CachedWordFinder(matrix, _defaultTopCount);
            case FinderTypes.DeepFirstSearch:
                return new DFSWordFinder(matrix, _defaultTopCount);
            default:
                throw new NotImplementedException($"{type} not implemented");
        }
    }
}