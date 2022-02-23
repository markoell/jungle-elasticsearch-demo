// See https://aka.ms/new-console-template for more information
public record Rootobject
{
    public string name { get; set; }
    public int price { get; set; }
    public int in_stock { get; set; }
    public int sold { get; set; }
    public string[] tags { get; set; }
    public string description { get; set; }
    public bool is_active { get; set; }
    public string created { get; set; }
}
