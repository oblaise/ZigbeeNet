``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.406
  [Host]     : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT
  DefaultJob : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT


```
|         Method |          Mean |      Error |     StdDev |
|--------------- |--------------:|-----------:|-----------:|
|            Get | 1,464.3523 ns | 27.0953 ns | 52.2034 ns |
| GetSquareArray |     2.3152 ns |  0.1468 ns |  0.1748 ns |
|       GetArray |     0.3927 ns |  0.0864 ns |  0.0808 ns |
