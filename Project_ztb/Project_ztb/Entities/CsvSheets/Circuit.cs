using Project_ztb.Entities.Common;

namespace Project_ztb.Entities;

public class Circuit : ISheet
{
    public int circuitId { get; set; }
    public string circuitRef { get; set; }
    public string name { get; set; }
    public string location { get; set; }
    public string country { get; set; }
    public string lat { get; set; }
    public string lng { get; set; }
    public string alt { get; set; }
}