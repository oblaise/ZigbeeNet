``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.406
  [Host]     : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT
  DefaultJob : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT


```
|         Method |          Mean |      Error |     StdDev |
|--------------- |--------------:|-----------:|-----------:|
|            Get | 1,486.0311 ns | 28.8035 ns | 32.0150 ns |
| GetSquareArray |     7.5706 ns |  0.0831 ns |  0.0736 ns |
|       GetArray |     0.3675 ns |  0.1029 ns |  0.0859 ns |
