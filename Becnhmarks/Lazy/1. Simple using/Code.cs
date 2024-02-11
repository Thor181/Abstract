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
