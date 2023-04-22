``` ini

BenchmarkDotNet=v0.13.5, OS=macOS Monterey 12.5.1 (21G83) [Darwin 21.6.0]
Apple M1 Pro 2.40GHz, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.404
  [Host]     : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT SSE4.2
  DefaultJob : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT SSE4.2


```
|          Method |               record |      finderType |             Mean |          Error |         StdDev | Rank |         Gen0 |      Gen1 |      Gen2 |    Allocated |
|---------------- |--------------------- |---------------- |-----------------:|---------------:|---------------:|-----:|-------------:|----------:|----------:|-------------:|
| **SearchOperation** | **Examp(...)g[] } [71]** |      **BruteForce** |         **9.096 μs** |      **0.0726 μs** |      **0.0679 μs** |    **2** |       **4.9591** |         **-** |         **-** |      **10376 B** |
| SearchOperation | Examp(...)g[] } [71] |      BruteForce |     1,680.019 μs |     33.1085 μs |     48.5300 μs |    7 |     570.3125 |         - |         - |    1195707 B |
| SearchOperation | Examp(...)g[] } [71] |      BruteForce | 1,524,255.640 μs | 29,269.9415 μs | 39,074.5312 μs |   15 |  550000.0000 |         - |         - | 1150179456 B |
| SearchOperation | Examp(...)g[] } [71] |      BruteForce | 3,001,500.701 μs | 59,477.3610 μs | 73,043.5407 μs |   16 | 1100000.0000 |         - |         - | 2300325952 B |
| **SearchOperation** | **Examp(...)g[] } [71]** |            **Linq** |         **9.689 μs** |      **0.1643 μs** |      **0.2408 μs** |    **3** |       **5.3253** |         **-** |         **-** |      **11144 B** |
| SearchOperation | Examp(...)g[] } [71] |            Linq |     1,444.686 μs |     28.3154 μs |     34.7738 μs |    6 |     478.5156 |         - |         - |    1004397 B |
| SearchOperation | Examp(...)g[] } [71] |            Linq |    18,337.664 μs |    162.1210 μs |    151.6481 μs |    8 |    5437.5000 |         - |         - |   11404846 B |
| SearchOperation | Examp(...)g[] } [71] |            Linq |    24,007.001 μs |    156.0374 μs |    138.3231 μs |   10 |    5437.5000 |         - |         - |   11404850 B |
| **SearchOperation** | **Examp(...)g[] } [71]** |    **CachedMatrix** |        **32.409 μs** |      **0.5696 μs** |      **0.5328 μs** |    **4** |      **18.6768** |         **-** |         **-** |      **39152 B** |
| SearchOperation | Examp(...)g[] } [71] |    CachedMatrix |    21,385.240 μs |    427.6099 μs |    834.0203 μs |    9 |    2625.0000 | 1437.5000 |  906.2500 |   16991275 B |
| SearchOperation | Examp(...)g[] } [71] |    CachedMatrix |    34,392.495 μs |    640.2582 μs |  1,202.5602 μs |   11 |    3714.2857 | 1714.2857 | 1000.0000 |   21024570 B |
| SearchOperation | Examp(...)g[] } [71] |    CachedMatrix |    42,353.042 μs |    844.7328 μs |    705.3902 μs |   12 |    5307.6923 | 2461.5385 | 1153.8462 |   25058569 B |
| **SearchOperation** | **Examp(...)g[] } [71]** | **DeepFirstSearch** |         **1.301 μs** |      **0.0241 μs** |      **0.0247 μs** |    **1** |       **0.4387** |         **-** |         **-** |        **920 B** |
| SearchOperation | Examp(...)g[] } [71] | DeepFirstSearch |       368.882 μs |      0.7980 μs |      0.7074 μs |    5 |       6.8359 |         - |         - |      14304 B |
| SearchOperation | Examp(...)g[] } [71] | DeepFirstSearch |   333,306.812 μs |  4,057.0032 μs |  3,596.4276 μs |   13 |    1500.0000 |         - |         - |    4047872 B |
| SearchOperation | Examp(...)g[] } [71] | DeepFirstSearch |   655,486.696 μs |  8,981.4849 μs |  7,961.8525 μs |   14 |    3000.0000 |         - |         - |    8086944 B |