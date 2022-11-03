using Project_ztb.Entities.Common;

namespace Project_ztb.Entities;

public class Constructor_standing : ISheet
{
    public int constructorStandingsId { get; set; }
    public string raceId { get; set; }
    public string constructorId { get; set; }
    public string points { get; set; }
    public string position { get; set; }
    public string positionText { get; set; }
    public string wins { get; set; }
}