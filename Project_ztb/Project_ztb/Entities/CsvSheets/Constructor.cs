using Project_ztb.Entities.Common;

namespace Project_ztb.Entities;

public class Constructor : ISheet
{
    public int constructorId { get; set; }
    public string constructorRef { get; set; }
    public string name { get; set; }
    public string nationality { get; set; }
}