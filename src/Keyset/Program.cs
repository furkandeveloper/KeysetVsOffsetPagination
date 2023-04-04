// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");





static List<TestData> GenerateTestData(int count)
{
    var testData = new List<TestData>();
    for (int i = 0; i < count; i++)
    {
        testData.Add(new TestData { Id = Guid.NewGuid(), Value = i });
    }
    return testData;
}


class TestData
{
    public Guid Id { get; set; }
    public int Value { get; set; }
}