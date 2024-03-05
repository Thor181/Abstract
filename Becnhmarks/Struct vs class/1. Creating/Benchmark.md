
| Method | Count |     Mean |    Error |   StdDev |    Gen0 | Allocated |
|------- |------ |---------:|---------:|---------:|--------:|----------:|
| Struct | 10000 | 52.08 us | 0.612 us | 0.542 us |       - |         - |
|  Class | 10000 | 32.47 us | 0.644 us | 1.673 us | 50.9644 |  480000 B |

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

