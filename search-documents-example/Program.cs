// See https://aka.ms/new-console-template for more information
using Nest;

var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
        .DefaultIndex("default")
        //.BasicAuthentication("elastic", "gMFJbCqZR6HFlArw21bd")
        .ApiKeyAuthentication("ARk2J38BO4QHpYt-7Df1", "GkIpG_uNQtyHX296e7I2WA")
        .DisableDirectStreaming();

var client = new ElasticClient(connectionSettings);

var result = await client.SearchAsync<MyRecord>(s => s.Index("myindex").Query(q => q.MatchAll()));

foreach (var record in result.Documents)
{
    Console.WriteLine(record);
}

Console.WriteLine();
Console.WriteLine("##############################################");
Console.WriteLine();
Console.WriteLine(result.DebugInformation);


public record MyRecord
{
    public string Message { get; set; }
    public int Rating { get; set; }
}