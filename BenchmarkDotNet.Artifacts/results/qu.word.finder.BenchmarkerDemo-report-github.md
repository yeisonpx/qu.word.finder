``` ini

BenchmarkDotNet=v0.13.5, OS=macOS Monterey 12.5.1 (21G83) [Darwin 21.6.0]
Apple M1 Pro 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.404
  [Host]     : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT SSE4.2
  DefaultJob : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT SSE4.2


```
|              Method |               record |          Mean |       Error |      StdDev | Rank |     Gen0 |     Gen1 |    Gen2 |  Allocated |
|-------------------- |--------------------- |--------------:|------------:|------------:|-----:|---------:|---------:|--------:|-----------:|
|     UsingLinqFinder | Examp(...)g[] } [71] |      3.056 μs |   0.0174 μs |   0.0154 μs |    1 |   1.6060 |        - |       - |    3.28 KB |
|     UsingLinqFinder | Examp(...)g[] } [71] |    651.609 μs |   9.8986 μs |   8.7749 μs |    3 |  16.6016 |        - |       - |   34.62 KB |
|     UsingLinqFinder | Examp(...)g[] } [71] |  6,562.681 μs |  41.8730 μs |  37.1193 μs |    7 | 101.5625 |        - |       - |  216.27 KB |
| UsingIteratorFinder | Examp(...)g[] } [71] |      3.030 μs |   0.0262 μs |   0.0219 μs |    1 |   1.0414 |        - |       - |    2.13 KB |
| UsingIteratorFinder | Examp(...)g[] } [71] |  1,732.056 μs |  17.9262 μs |  16.7682 μs |    4 |   9.7656 |        - |       - |    23.8 KB |
| UsingIteratorFinder | Examp(...)g[] } [71] | 13,525.286 μs | 141.3548 μs | 125.3074 μs |    8 |        - |        - |       - |   26.79 KB |
|   UsingCachedFinder | Examp(...)g[] } [71] |     11.942 μs |   0.2347 μs |   0.4900 μs |    2 |   7.6294 |        - |       - |   15.61 KB |
|   UsingCachedFinder | Examp(...)g[] } [71] |  2,607.938 μs |  50.0297 μs |  70.1346 μs |    5 | 531.2500 | 218.7500 | 93.7500 | 1987.16 KB |
|   UsingCachedFinder | Examp(...)g[] } [71] |  2,685.726 μs |  51.5657 μs |  57.3151 μs |    6 | 546.8750 | 226.5625 | 93.7500 | 2025.91 KB |
