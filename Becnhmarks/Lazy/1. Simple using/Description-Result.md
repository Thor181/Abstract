
|     Method |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|----------- |---------:|---------:|---------:|-------:|----------:|
|  LazyClass | 12.52 ns | 0.102 ns | 0.091 ns | 0.0102 |      96 B |
| PlainClass | 38.33 ns | 0.351 ns | 0.329 ns | 0.0255 |     240 B |

```csharp
[MemoryDiagnoser]
public class Test
{
    [Benchmark]
    public void LazyClass()
    { 
        var cl = new LazyClass();
    }

    [Benchmark]
    public void PlainClass()
    {
        var cl = new PlainClass();
    }
}

public class LazyClass
{
    public Lazy<Dictionary<string, string>> Dict { get; set; }

    public LazyClass()
    {
        Dict = new Lazy<Dictionary<string, string>>(() => new Dictionary<string, string>() { { "key1", "value1" }, { "key2", "value2" } }) ;
    }
}

public class PlainClass
{
    public Dictionary<string, string> Dict { get; set; }

    public PlainClass()
    {
        Dict = new Dictionary<string, string>() { { "key1", "value1" }, { "key2", "value2" } };
    }
}
```
