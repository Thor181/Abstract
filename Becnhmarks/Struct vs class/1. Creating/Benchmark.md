
| Method | Count |     Mean |    Error |   StdDev | Allocated |
|------- |------ |---------:|---------:|---------:|----------:|
| Struct |  1000 | 91.43 ms | 1.563 ms | 1.605 ms |      40 B |
|  Class |  1000 | 88.26 ms | 1.130 ms | 1.057 ms |   48091 B |

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
            var res = UseStruct(a);
            Console.WriteLine(res.A);
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
            var res = UseClass(a);
            Console.WriteLine(res.A);
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

