BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.3155/22H2/2022Update/SunValley2)
12th Gen Intel Core i5-12400F, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 6.0.27 (6.0.2724.6912), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.27 (6.0.2724.6912), X64 RyuJIT AVX2


|        Method | Count |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|-------------- |------ |----------:|----------:|----------:|-------:|----------:|
| Interpolation | 10000 | 25.086 ns | 0.4998 ns | 0.3902 ns | 0.0034 |      32 B |
|      ToString | 10000 |  9.221 ns | 0.0904 ns | 0.0845 ns | 0.0034 |      32 B |

```csharp
namespace Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Test>();
        }
    }

    [MemoryDiagnoser]
    public class Test
    {
        [Params(10000)]
        public int Count { get; set; }

        public static string First;
        public static string Second;

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public void Interpolation()
        {
            First = $"{Count}";
        }

        [Benchmark]
        public void ToString()
        {
            Second = Count.ToString();
        }


    }
}
```
