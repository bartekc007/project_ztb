using Project_ztb.Entities.Common;

namespace Project_ztb.Entities;

public class Result : ISheet
{
    public int resultId { get; set; }
    public string raceId { get; set; }
    public string driverId { get; set; }
    public string constructorId { get; set; }
    public string number { get; set; }
    public string grid { get; set; }
    public string position { get; set; }
    public string positionText { get; set; }
    public string positionOrder { get; set; }
    public string points { get; set; }
}