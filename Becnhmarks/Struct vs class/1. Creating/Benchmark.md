
| Method | Count |       Mean |    Error |   StdDev |   Gen0 | Allocated |
|------- |------ |-----------:|---------:|---------:|-------:|----------:|
| Struct |  1000 |   247.9 ns |  4.24 ns |  3.96 ns |      - |         - |
|  Class |  1000 | 1,850.3 ns | 35.90 ns | 33.58 ns | 2.5520 |   24024 B |

```csharp
[MemoryDiagnoser]
public class Test
{
    [Params(1000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    [Benchmark]
    public TestStruct Struct()
    {
        for (int i = 0; i < Count; i++)
        {
            var a = new TestStruct();
            UseStruct(a);
        }

        return new TestStruct();
    }

    private TestStruct UseStruct(TestStruct testStruct)
    {
        testStruct.A = 1;
        return testStruct;
    }

    [Benchmark]
    public TestClass Class()
    {
        for (int i = 0; i < Count; i++)
        {
            var a = new TestClass();
            UseClass(a);
        }

        return new TestClass();
    }

    private TestClass UseClass(TestClass testClass)
    {
        testClass.A = 1;
        return testClass;
    }

}
```

