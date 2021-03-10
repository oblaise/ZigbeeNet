``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.407
  [Host]     : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT
  DefaultJob : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT


```
|         Method |          Mean |      Error |     StdDev |
|--------------- |--------------:|-----------:|-----------:|
|            Get | 1,464.0581 ns | 14.1086 ns | 11.7813 ns |
|        GetDict |    10.2695 ns |  0.1114 ns |  0.0870 ns |
|  GetKeyedValue |    18.2015 ns |  0.4702 ns |  0.5775 ns |
| GetSquareArray |     2.7174 ns |  0.1224 ns |  0.1085 ns |
|       GetArray |     0.4355 ns |  0.0930 ns |  0.0870 ns |
