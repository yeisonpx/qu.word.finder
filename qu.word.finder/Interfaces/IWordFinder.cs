namespace qu.word.finder.Interfaces;

public interface IWordFinder
{
    IEnumerable<string> Find(IEnumerable<string> wordstream);
}