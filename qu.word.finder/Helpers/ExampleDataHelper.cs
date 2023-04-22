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


    public static ExampleDataRecord GetExampleDataFromFile(string matrixFileName, string wordsExampleFile)
    {
        var matrix = File.ReadLines($"{AssemblyDirectory}/Helpers/Resources/{matrixFileName}").ToArray();
        var words = File.ReadLines($"{AssemblyDirectory}/Helpers/Resources/{wordsExampleFile}").ToArray();
        
        return new ExampleDataRecord(matrix, words);
    }


    public static ExampleDataRecord GetExampleData(ExampleDataSize size) => size switch
    {
        ExampleDataSize.FiveWords => GetMatrix6x6_With_5_Words(),

        ExampleDataSize.OneHundred => GetExampleDataFromFile("40x64_example.txt","words_100.txt"),
        ExampleDataSize.OneHundredThousand => GetExampleDataFromFile("40x64_example.txt","words_100k.txt"),
        ExampleDataSize.TwoHundredThousand => GetExampleDataFromFile("40x64_example.txt","words_200k.txt"),
        ExampleDataSize.OneMillion => GetExampleDataFromFile("40x64_example.txt","words_1M.txt")
    };
    
    public enum ExampleDataSize
    {
        FiveWords,
        OneHundred,
        OneHundredThousand,
        TwoHundredThousand,
        OneMillion
    }

    public static IEnumerable<object[]> GetMatrixValues(){
        
        var matrix6X6With5Words =  GetExampleData(ExampleDataSize.FiveWords);
        var matrix40X64With100 = GetExampleData(ExampleDataSize.OneHundred);
        var matrix40X64With100KWords =GetExampleData(ExampleDataSize.OneHundredThousand);
        var matrix40X64With200KWords =GetExampleData(ExampleDataSize.TwoHundredThousand);
        var matrix40X64WithOneMillion = GetExampleData(ExampleDataSize.OneMillion);
        
        return new[]
        {
            new object [] {  matrix6X6With5Words, FinderTypes.Linq },

            new object [] {  matrix40X64With100, FinderTypes.Linq },
            new object [] {  matrix40X64With100KWords, FinderTypes.Linq },
            new object [] {  matrix40X64With200KWords, FinderTypes.Linq },
            new object [] {  matrix40X64WithOneMillion, FinderTypes.Linq },
            new object [] {  matrix6X6With5Words, FinderTypes.BruteForce },
            new object [] {  matrix40X64With100, FinderTypes.BruteForce },
            new object [] {  matrix40X64With100KWords, FinderTypes.BruteForce },
            new object [] {  matrix40X64With200KWords, FinderTypes.BruteForce },
            new object [] {  matrix40X64WithOneMillion, FinderTypes.BruteForce },
            new object [] {  matrix6X6With5Words, FinderTypes.CachedMatrix },
            new object [] {  matrix40X64With100, FinderTypes.CachedMatrix },
            new object [] {  matrix40X64With100KWords, FinderTypes.CachedMatrix },
            new object [] {  matrix40X64With200KWords, FinderTypes.CachedMatrix },
            new object [] {  matrix40X64WithOneMillion, FinderTypes.CachedMatrix },
            new object [] {  matrix6X6With5Words, FinderTypes.DeepFirstSearch },
            new object [] {  matrix40X64With100, FinderTypes.DeepFirstSearch },
            new object [] {  matrix40X64With100KWords, FinderTypes.DeepFirstSearch },
            new object [] {  matrix40X64With200KWords, FinderTypes.DeepFirstSearch },
            new object [] {  matrix40X64WithOneMillion, FinderTypes.DeepFirstSearch }
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