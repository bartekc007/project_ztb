using Project_ztb.Entities.Common;

namespace Project_ztb.Entities;

public class Race : ISheet
{
    public int raceId { get; set; }
    public string year { get; set; }
    public string round { get; set; }
    public string circuitId { get; set; }
    public string name { get; set; }
    public string date { get; set; }
    public string time { get; set; }
}