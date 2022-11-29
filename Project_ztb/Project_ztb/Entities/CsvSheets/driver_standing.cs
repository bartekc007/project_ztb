using Project_ztb.Entities.Common;

namespace Project_ztb.Entities;

public class Driver_standing : ISheet
{
    public int driverStandingsId { get; set; }
    public string raceId { get; set; }
    public string driverId { get; set; }
    public string points { get; set; }
    public string position { get; set; }
    public string positionText { get; set; }
    public string wins { get; set; }
}