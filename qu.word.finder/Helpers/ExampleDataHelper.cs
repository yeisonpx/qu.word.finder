using System.Reflection;
using qu.word.finder.Interfaces;

namespace qu.word.finder.Helpers;

public static class ExamplesHelper
{
    public static ExampleDataRecord GetMatrix6x6_With_5_Words()
    {
        var matrix = new[]
        {
            "1bcdcccc",
            "fgwioooo",
            "chilllll",
            "pqnsdddd",
            "uvdxyldd",
            "chilladd",
            "dwindadd",
        }; 
        
        var words = new[] 
        {
            "cold",
            "wind",
            "snow",
            "chill"
        };

        return new ExampleDataRecord(matrix, words);
    }
    
    public static ExampleDataRecord GetMatrix40x64_With_100k_Words()
    {
        var matrix = File.ReadLines($"{AssemblyDirectory}/Helpers/Resources/40x64_example.txt").ToArray();
        var words = File.ReadLines($"{AssemblyDirectory}/Helpers/Resources/words_100k.txt").ToArray();
        
        return new ExampleDataRecord(matrix, words);
    }
    
    public static ExampleDataRecord GetMatrix40x64_With_200k_Words()
    {
        var matrix = File.ReadLines($"{AssemblyDirectory}/Helpers/Resources/40x64_example.txt").ToArray();
        var words = File.ReadLines($"{AssemblyDirectory}/Helpers/Resources/words_200k.txt").ToArray();
        
        return new ExampleDataRecord(matrix, words);
    }

    public static ExampleDataRecord GetMatrix40x64_With_100_Words()
    {
        var matrix = File.ReadLines($"{AssemblyDirectory}/Helpers/Resources/40x64_example.txt").ToArray();
        var words = File.ReadLines($"{AssemblyDirectory}/Helpers/Resources/words_100.txt").ToArray();
        
        return new ExampleDataRecord(matrix, words);
    }


    public static ExampleDataRecord GetExampleData(ExampleDataSize size) => size switch
    {
        ExampleDataSize.FiveWords => GetMatrix6x6_With_5_Words(),
        ExampleDataSize.OneHundred => GetMatrix40x64_With_100_Words(),
        ExampleDataSize.OneHundredThousand => GetMatrix40x64_With_100k_Words(),
        ExampleDataSize.TwoHundredThousand => GetMatrix40x64_With_200k_Words()
    };
    
    public enum ExampleDataSize
    {
        FiveWords,
        OneHundred,
        OneHundredThousand,
        TwoHundredThousand
    }

    public static IEnumerable<object[]> GetMatrixValues(){
        
        var matrix6X6With5Words = GetMatrix6x6_With_5_Words();
        var matrix40X64With100 = GetMatrix40x64_With_100_Words();
        var matrix40X64With1KWords = GetMatrix40x64_With_100k_Words();
        var matrix40X64With2KWords = GetMatrix40x64_With_200k_Words();
        
        return new[]
        {
            new object [] {  matrix6X6With5Words, FinderTypes.Linq },
            new object [] {  matrix6X6With5Words, FinderTypes.BruteForce },
            new object [] {  matrix6X6With5Words, FinderTypes.CachedMatrix },
            new object [] {  matrix6X6With5Words, FinderTypes.DeepFirstSearch },
            new object [] {  matrix40X64With100, FinderTypes.Linq },
            new object [] {  matrix40X64With100, FinderTypes.BruteForce },
            new object [] {  matrix40X64With100, FinderTypes.CachedMatrix },
            new object [] {  matrix40X64With100, FinderTypes.DeepFirstSearch },
            new object [] {  matrix40X64With1KWords, FinderTypes.Linq },
            new object [] {  matrix40X64With1KWords, FinderTypes.BruteForce },
            new object [] {  matrix40X64With1KWords, FinderTypes.CachedMatrix },
            new object [] {  matrix40X64With1KWords, FinderTypes.DeepFirstSearch },
            new object [] {  matrix40X64With2KWords, FinderTypes.Linq },
            new object [] {  matrix40X64With2KWords, FinderTypes.BruteForce },
            new object [] {  matrix40X64With2KWords, FinderTypes.CachedMatrix },
            new object [] {  matrix40X64With2KWords, FinderTypes.DeepFirstSearch }
        };
    }
    
    public static string AssemblyDirectory
    {
        get
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }

}