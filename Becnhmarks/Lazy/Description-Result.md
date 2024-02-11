


|     Method |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|----------- |---------:|---------:|---------:|-------:|----------:|
|  LazyClass | 12.52 ns | 0.102 ns | 0.091 ns | 0.0102 |      96 B |
| PlainClass | 38.33 ns | 0.351 ns | 0.329 ns | 0.0255 |     240 B |



|     Method |     Mean |   Error |  StdDev |   Gen0 |   Gen1 | Allocated |
|----------- |---------:|--------:|--------:|-------:|-------:|----------:|
|  LazyClass | 404.8 ns | 4.52 ns | 4.01 ns | 0.2685 | 0.0019 |   2.47 KB |
| PlainClass | 975.7 ns | 4.45 ns | 3.48 ns | 0.5741 | 0.0095 |   5.28 KB |
