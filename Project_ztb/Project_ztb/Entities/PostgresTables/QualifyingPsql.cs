namespace Project_ztb.Entities.PostgresTables;

public class QualifyingPsql
{
    public int qualifying_Id { get; set; }
    public int race_Id { get; set; }
    public int driver_Id { get; set; }
    public int constructor_Id { get; set; }
    public string qualifying_position { get; set; }
    public string qualifying_q1 { get; set; }
    public string qualifying_q2 { get; set; }
    public string qualifying_q3 { get; set; }
}