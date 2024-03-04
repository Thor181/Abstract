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
