using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<PaginationBenchmark>();

public class PaginationBenchmark
{
    private List<TestData> testData;
    private int pageSize;
    private Guid lastId;

    [Params(1000, 10000, 100000)]
    public int ItemCount { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        testData = GenerateTestData(ItemCount);
        pageSize = 100;
        lastId = Guid.Empty;
    }

    [Benchmark]
    public void KeysetPagination()
    {
        var results = new List<TestData>();
        while (true)
        {
            var query = testData.Where(x => x.Id > lastId).OrderBy(x => x.Id).Take(pageSize);
            var pageResults = query.ToList();
            results.AddRange(pageResults);
            if (pageResults.Count < pageSize)
                break;
            lastId = pageResults.Last().Id;
        }
    }

    [Benchmark]
    public void OffsetPagination()
    {
        var results = new List<TestData>();
        var offset = 0;
        while (true)
        {
            var query = testData.OrderBy(x => x.Id).Skip(offset).Take(pageSize);
            var pageResults = query.ToList();
            results.AddRange(pageResults);
            if (pageResults.Count < pageSize)
                break;
            offset += pageSize;
        }
    }

    private List<TestData> GenerateTestData(int count)
    {
        var testData = new List<TestData>();
        for (int i = 0; i < count; i++)
        {
            testData.Add(new TestData { Id = Guid.NewGuid(), Value = i });
        }
        return testData;
    }
}

class TestData
{
    public Guid Id { get; set; }
    public int Value { get; set; }
}