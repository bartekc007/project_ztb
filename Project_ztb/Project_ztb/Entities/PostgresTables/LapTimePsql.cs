namespace Project_ztb.Entities.PostgresTables;

public class LapTimePsql
{
    public int race_Id { get; set; }
    public int driver_Id { get; set; }
    public string lap { get; set; }
    public string lap_time_position { get; set; }
    public string lap_time_time { get; set; }
}