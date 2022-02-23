// See https://aka.ms/new-console-template for more information
using Nest;

var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
        .DefaultIndex("default")
        //.BasicAuthentication("elastic", "gMFJbCqZR6HFlArw21bd")
        .ApiKeyAuthentication("ARk2J38BO4QHpYt-7Df1", "GkIpG_uNQtyHX296e7I2WA")
        .DisableDirectStreaming();

var client = new ElasticClient(connectionSettings);

var result = await client.SearchAsync<Rootobject>(s => s.Index("products").Query(q => q.MatchAll()));
Console.WriteLine(result.DebugInformation);
