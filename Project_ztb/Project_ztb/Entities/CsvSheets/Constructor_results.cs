using Project_ztb.Entities.Common;

namespace Project_ztb.Entities;

public class Constructor_results : ISheet
{
    public int constructorResultsId { get; set; }
    public string raceId { get; set; }
    public string constructorId { get; set; }
    public string points { get; set; }
    public string status { get; set; }
}