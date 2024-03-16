BenchmarkDotNet v0.13.7, Windows 11 (10.0.22631.3296)
12th Gen Intel Core i5-12400F, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.200
  [Host]   : .NET 6.0.27 (6.0.2724.6912), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.27 (6.0.2724.6912), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


|       Method |      Job |  Runtime | Count |     Mean |   Error |   StdDev |   Median |    Gen0 | Allocated |
|------------- |--------- |--------- |------ |---------:|--------:|---------:|---------:|--------:|----------:|
| SimpleConcat | .NET 6.0 | .NET 6.0 | 10000 | 217.0 us | 4.29 us |  8.57 us | 216.1 us | 83.9844 | 773.13 KB |
|  Interpolate | .NET 6.0 | .NET 6.0 | 10000 | 203.9 us | 3.60 us |  3.36 us | 204.2 us | 83.9844 | 773.13 KB |
| StringFormat | .NET 6.0 | .NET 6.0 | 10000 | 363.0 us | 7.10 us | 11.86 us | 363.2 us | 83.9844 | 773.13 KB |
| StringConcat | .NET 6.0 | .NET 6.0 | 10000 | 204.4 us | 4.03 us |  3.96 us | 205.1 us | 83.9844 | 773.13 KB |
| SimpleConcat | .NET 8.0 | .NET 8.0 | 10000 | 106.2 us | 2.04 us |  2.35 us | 107.3 us | 83.1299 | 764.06 KB |
|  Interpolate | .NET 8.0 | .NET 8.0 | 10000 | 106.3 us | 2.10 us |  3.34 us | 105.9 us | 83.1299 | 764.06 KB |
| StringFormat | .NET 8.0 | .NET 8.0 | 10000 | 362.4 us | 7.18 us | 10.97 us | 362.7 us | 83.0078 | 764.06 KB |
| StringConcat | .NET 8.0 | .NET 8.0 | 10000 | 105.2 us | 2.05 us |  2.81 us | 103.5 us | 83.1299 | 764.06 KB |

```csharp
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60)]
[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net80)]
[MemoryDiagnoser]
public class Test
{
    [Params(10000)]
    public int Count { get; set; }
    public static string SimpleConcatedStr;
    public static string InterpolatedStr;
    public static string FormattedStr;

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark]
    public void SimpleConcat()
    {
        for (int i = 0; i < Count; i++)
        {
            var val = i.ToString();
            SimpleConcatedStr = "123" + val + "321";
        }
    }

    [Benchmark]
    public void Interpolate()
    {
        for (int i = 0; i < Count; i++)
        {
            var val = i.ToString();
            InterpolatedStr = $"123{val}321";
        }
    }

    [Benchmark]
    public void StringFormat()
    {
        for (int i = 0; i < Count; i++)
        {
            var val = i.ToString();
            FormattedStr = string.Format("123{0}321", val);
        }
    }

    [Benchmark]
    public void StringConcat()
    {
        for (int i = 0; i < Count; i++)
        {
            var val = i.ToString();
            FormattedStr = string.Concat("123", val, "321");
        }
    }


}
```
