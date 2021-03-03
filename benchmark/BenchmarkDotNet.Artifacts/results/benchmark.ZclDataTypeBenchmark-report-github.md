``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.406
  [Host]     : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT
  DefaultJob : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT


```
|         Method |         Mean |      Error |     StdDev |
|--------------- |-------------:|-----------:|-----------:|
|            Get | 1,622.791 ns | 28.0654 ns | 28.8211 ns |
|        GetDict |    15.973 ns |  0.2564 ns |  0.2273 ns |
|  GetKeyedValue |    17.895 ns |  0.2803 ns |  0.2485 ns |
| GetSquareArray |     2.333 ns |  0.0864 ns |  0.0765 ns |
