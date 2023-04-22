using BenchmarkDotNet.Attributes;
using qu.word.finder.Helpers;
using qu.word.finder.Interfaces;

namespace qu.word.finder;

/// <summary>
/// This class allows to run benchmark using the different strategies and evaluate the performance
/// </summary>
[MemoryDiagnoser]
[RankColumn]
public class BenchmarkDemo
{
    private readonly IWordFinderFactory _factory;
    public BenchmarkDemo() => _factory = new WordFinderFactory();
    
    [Benchmark]
    [ArgumentsSource(nameof(GetMatrixValues))]
    public List<string> SearchOperation(ExampleDataRecord record, FinderTypes finderType)
    {
        IWordFinder finder = _factory.Get(finderType, record.Matrix);
        return finder.Find(record.Words).ToList();
    }
    
    public static IEnumerable<object[]> GetMatrixValues() => ExamplesHelper.GetMatrixValues();
}