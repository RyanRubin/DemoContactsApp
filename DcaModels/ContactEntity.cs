namespace DcaModels;

public class ContactEntity : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Number { get; set; }
    public int ColorR { get; set; }
    public int ColorG { get; set; }
    public int ColorB { get; set; }
}
