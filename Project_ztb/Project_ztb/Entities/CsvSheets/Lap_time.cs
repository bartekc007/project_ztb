using Project_ztb.Entities.Common;

namespace Project_ztb.Entities;

public class Lap_time : ISheet
{
    public int raceId { get; set; }
    public string driverId { get; set; }
    public string lap { get; set; }
    public string position { get; set; }
    public string time { get; set; }
}