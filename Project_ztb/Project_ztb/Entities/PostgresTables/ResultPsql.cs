namespace Project_ztb.Entities.PostgresTables;

public class ResultPsql
{
    public int result_Id { get; set; }
    public int race_Id { get; set; }
    public int driver_Id { get; set; }
    public int constructor_Id { get; set; }
    public string result_Number { get; set; }
    public string result_Grid { get; set; }
    public string result_Position { get; set; }
    public string result_Position_Text { get; set; }
    public string result_Position_Order { get; set; }
    public string result_Points { get; set; }
}