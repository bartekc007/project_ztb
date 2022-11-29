namespace Project_ztb.Entities.PostgresTables;

public class SprintResultPsql
{
    public int sprint_resultId { get; set; }
    public int race_Id { get; set; }
    public int driver_Id { get; set; }
    public int constructor_Id { get; set; }
    public string sprint_result_number { get; set; }
    public string sprint_result_grid { get; set; }
    public string sprint_result_position { get; set; }
    public string sprint_result_position_text { get; set; }
    public string sprint_result_position_order { get; set; }
    public string rsprint_result_points { get; set; }
}