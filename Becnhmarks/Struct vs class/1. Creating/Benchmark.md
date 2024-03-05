
| Method | Count |     Mean |    Error |   StdDev | Allocated |
|------- |------ |---------:|---------:|---------:|----------:|
| Struct |  1000 | 91.43 ms | 1.563 ms | 1.605 ms |      40 B |
|  Class |  1000 | 88.26 ms | 1.130 ms | 1.057 ms |   48091 B |

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

        public TestClass TCl;
        public static TestStruct T;

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
                T = res;
            }

            return T;
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
                TCl = res;
            }

            return TCl;
        }

        private TestClass UseClass(TestClass testClass)
        {
            testClass.A = 1;
            return testClass;
        }
    }

    public class TestClass
    {
        public int A { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
        public int A4 { get; set; }
        public int A5 { get; set; }
        public int A6 { get; set; }
        public int A7 { get; set; }
        public int A8 { get; set; }
    }

    public struct TestStruct
    {
        public int A { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
        public int A4 { get; set; }
        public int A5 { get; set; }
        public int A6 { get; set; }
        public int A7 { get; set; }
        public int A8 { get; set; }
    }
}
```

