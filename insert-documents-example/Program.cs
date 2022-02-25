// See https://aka.ms/new-console-template for more information
using Nest;

var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
        .DefaultIndex("default")
        .BasicAuthentication("elastic", "gMFJbCqZR6HFlArw21bd");

var client = new ElasticClient(connectionSettings);

var document = new MyRecord
{
    Message = "I'm from .NET",
    Rating = 4
};

var response = await client.IndexAsync(document, g => g.Index("mydotnetindex").Id(100));

if (response.IsValid)
{
    Console.WriteLine("Insert Succeeded");
}

var result = await client.SearchAsync<MyRecord>(s => s.Index("mydotnetindex").Query(q => q.MatchAll()));

foreach (var record in result.Documents)
{
    Console.WriteLine(record);
}


public record MyRecord
{
    public string Message { get; set; }
    public int Rating { get; set; }
}