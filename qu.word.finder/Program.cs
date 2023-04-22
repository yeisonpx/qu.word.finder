// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using qu.word.finder;
using qu.word.finder.Helpers;
using qu.word.finder.Interfaces;

//Uncomment to show benchmark
// RunBenchmark();

//Execute Search
SearchWords(FinderTypes.DeepFirstSearch);
SearchWords(FinderTypes.BruteForce);
SearchWords(FinderTypes.Linq);
SearchWords(FinderTypes.CachedMatrix);

Console.ReadKey();

#region HelperMethods

    void SearchWords(FinderTypes type)
    {
        IWordFinderFactory factory = new WordFinderFactory();

        //Get example data
        var exampleData = ExamplesHelper.GetExampleData(ExamplesHelper.ExampleDataSize.TwoHundredThousand);
        var finder = factory.Get(type, exampleData.Matrix);
        var words = finder.Find(exampleData.Words);
        Console.WriteLine($"TOP {10}: Results using {type} strategy:");
        Console.WriteLine("-----------------------");
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine();
    }

    void RunBenchmark()
    {
        BenchmarkRunner.Run<BenchmarkDemo>();
    }


#endregion