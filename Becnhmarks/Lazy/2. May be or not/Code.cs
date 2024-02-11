[MemoryDiagnoser]
public class Test
{
    [Benchmark]
    public void LazyClass()
    {
        var cls = new List<LazyClass>();

        for (int i = 0; i < 20; i++)
        {
            cls.Add(new LazyClass());
        }

        for (int i = 0; i < 20; i++)
        {
            if (i % 2 == 0)
                Debug.WriteLine(cls[i].Dict.Value["key1"]);
        }
    }

    [Benchmark]
    public void PlainClass()
    {
        var cls = new List<PlainClass>();

        for (int i = 0; i < 20; i++)
        {
            cls.Add(new PlainClass());
        }

        for (int i = 0; i < 20; i++)
        {
            if (i % 2 == 0)
                Debug.WriteLine(cls[i].Dict["key1"]);
        }
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
