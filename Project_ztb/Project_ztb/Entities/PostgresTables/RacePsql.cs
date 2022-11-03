using System.Runtime.Versioning;

namespace Project_ztb.Entities.PostgresTables;

public class RacePsql
{
    public int race_Id { get; set; }
    public string race_Year { get; set; }
    public string race_Round { get; set; }
    public string circuit_Id { get; set; }
    public string race_Name { get; set; }
    public string race_Date { get; set; }
    public string race_Time { get; set; }
}