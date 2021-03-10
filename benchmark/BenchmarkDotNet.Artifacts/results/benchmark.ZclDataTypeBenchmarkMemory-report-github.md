``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.407
  [Host]     : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT
  DefaultJob : .NET Core 3.1.13 (CoreCLR 4.700.21.11102, CoreFX 4.700.21.11602), X64 RyuJIT


```
|            Method |       Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |-----------:|---------:|---------:|-------:|------:|------:|----------:|
|        CreateDict | 1,979.5 ns | 38.69 ns | 66.74 ns | 1.9875 |     - |     - |   3.05 KB |
|  CreateKeyedValue | 6,579.2 ns | 70.85 ns | 59.16 ns | 7.9041 |     - |     - |  12.13 KB |
|       CreateArray |   549.6 ns | 10.62 ns |  9.93 ns | 1.3351 |     - |     - |   2.05 KB |
| CreateSquareArray | 1,157.4 ns | 22.45 ns | 25.86 ns | 1.1768 |     - |     - |    1.8 KB |
