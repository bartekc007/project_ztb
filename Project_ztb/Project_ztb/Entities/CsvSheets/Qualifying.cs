using Project_ztb.Entities.Common;

namespace Project_ztb.Entities;

public class Qualifying : ISheet
{
    public int qualifyId { get; set; }
    public string raceId { get; set; }
    public string driverId { get; set; }
    public string constructorId { get; set; }
    public string number { get; set; }
    public string position { get; set; }
    public TimeSpan q1 { get; set; }
    public TimeSpan q2 { get; set; }
    public TimeSpan q3 { get; set; }
}