namespace qu.word.finder.Interfaces;

public interface IWordFinderFactory
{
    IWordFinder Get(FinderTypes type, IEnumerable<string> matrix);
}

public enum FinderTypes
{
    BruteForce,
    Linq,
    CachedMatrix,
    DeepFirstSearch
}