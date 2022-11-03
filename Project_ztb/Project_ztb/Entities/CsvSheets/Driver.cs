using Project_ztb.Entities.Common;

namespace Project_ztb.Entities;

public class Driver : ISheet
{
    public int driverId { get; set; }
    public string driverRef { get; set; }
    public string number { get; set; }
    public string code { get; set; }
    public string forename { get; set; }
    public string surname { get; set; }
    public DateTime dob { get; set; }
    public string nationality { get; set; }
}