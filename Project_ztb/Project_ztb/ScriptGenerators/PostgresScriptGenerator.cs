using System.Diagnostics.CodeAnalysis;
using System.Text;
using Project_ztb.Entities;
using Project_ztb.Entities.Common;
using Project_ztb.Entities.PostgresTables;

namespace Project_ztb.ScriptGenerators;

public class PostgresScriptGenerator
{
    private IDictionary<string, Func<IEnumerable<ISheet>, string>> generators =
        new Dictionary<string, Func<IEnumerable<ISheet>, string>>
        {
            {"circuits", GenerateCircuitsInsert},
            {"drivers", GenerateDriversInsert},
            {"constructors",GenerateConstructorsInsert},
            {"status",GenerateStatusesInsert},
            {"constructor_results",GenerateConstructorResultsInsert},
            {"constructor_standings",GenerateConstructorStandingsInsert},
            {"races",GenerateRacesInsert},
            {"driver_standings",GenerateDriverStandingInsert},
            {"lap_times",GenerateLapTimeInsert},
            {"qualifying",GenerateQualifyingInsert},
            {"results",GenerateResultInsert},
            {"sprint_results",GenerateSprintResultInsert}
        };
    
    public void GenerateFile(CsvSheet sheet,IEnumerable<ISheet> records)
    {
        if (generators.ContainsKey(sheet.ToString()))
        {
            string fileName ="postgres_" + sheet.ToString() + "_" + (Parameters.GetNumberOfRecords().HasValue
                ? Parameters.GetNumberOfRecords().Value.ToString()
                : "All");
            string path = $"../../../../../Scripts/Postgres/{fileName}.txt";
            if(File.Exists(path))
                File.Delete(path);
        
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(generators[sheet.ToString()].Invoke(records));
            }
        }
    }
    private static string GenerateCircuitsInsert(IEnumerable<ISheet> circuits)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO circuits ({nameof(CircuitPsql.circuit_Id)},{nameof(CircuitPsql.circuit_Ref)},{nameof(CircuitPsql.circuit_Name)},{nameof(CircuitPsql.circuit_Location)},{nameof(CircuitPsql.circuit_Lat)},{nameof(CircuitPsql.circuit_Ing)},{nameof(CircuitPsql.circuit_Alt)}) ");
        sb.AppendLine("Values ");
        foreach (var i in circuits)
        {
            Circuit item = (Circuit) i;
            sb.AppendLine(
                $"({item.circuitId},'{item.circuitRef}','{item.name.Replace('\'',' ')}','{item.location}',{item.lat},{item.lng},{item.alt}),"); 
        }
        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "0");
        sb.Append(";");
        return sb.ToString();
    }
    private static string GenerateDriversInsert(IEnumerable<ISheet> drivers)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO drivers ({nameof(DriverPsql.driver_Id)},{nameof(DriverPsql.driver_Ref)},{nameof(DriverPsql.driver_Number)},{nameof(DriverPsql.code)},{nameof(DriverPsql.forename)},{nameof(DriverPsql.surename)},{nameof(DriverPsql.dob)},{nameof(DriverPsql.natonality)}) ");
        sb.Append("Values ");
        foreach (var i in drivers)
        {
            Driver item = (Driver) i;
            sb.AppendLine(
                $"({item.driverId},'{item.driverRef.Replace('\'',' ')}','{item.number}','{item.code}','{item.forename.Replace('\'',' ')}','{item.surname.Replace('\'',' ')}','{item.dob}','{item.nationality}'),"); 
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "0");
        sb.Append(";");
        return sb.ToString();
    }
    private static string GenerateStatusesInsert(IEnumerable<ISheet> statuses)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO statuses ({nameof(StatusPsql.status_Id)},{nameof(StatusPsql.status_Name)}) ");
        sb.Append("Values ");
        foreach (var i in statuses)
        {
            Status item = (Status) i;
            sb.AppendLine(
                $"({item.statusId},'{item.status}'),"); 
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "0");
        sb.Append(";");
        return sb.ToString();
    }
    private static string GenerateConstructorsInsert(IEnumerable<ISheet> constructors)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO constructors ({nameof(ConstructorPsql.constructor_Id)},{nameof(ConstructorPsql.constructor_Ref)},{nameof(ConstructorPsql.constructor_Name)},{nameof(ConstructorPsql.constructor_Nationality)}) ");
        sb.Append("Values ");
        foreach (var i in constructors)
        {
            Constructor item = (Constructor) i;
            sb.AppendLine(
                $"({item.constructorId},'{item.constructorRef}','{item.name}','{item.nationality}'),"); 
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "0");
        sb.Append(";");
        return sb.ToString();
    }
    private static string GenerateConstructorResultsInsert(IEnumerable<ISheet> constructorsResults)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO constructor_results ({nameof(ConstructorResultPsql.constructor_result_Id)},{nameof(ConstructorResultPsql.race_Id)},{nameof(ConstructorResultPsql.constructor_Id)},{nameof(ConstructorResultPsql.constructor_result_Points)},{nameof(ConstructorResultPsql.status_Id)}) ");
        sb.Append("Values ");
        foreach (var i in constructorsResults)
        {
            Constructor_results item = (Constructor_results) i;
            sb.AppendLine(
                $"({item.constructorResultsId},{item.raceId},{item.constructorId},{item.points},{item.status}),"); 
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "2");
        sb.Replace("D", "2");
        sb.Append(";");
        return sb.ToString();
    }
    private static string GenerateConstructorStandingsInsert(IEnumerable<ISheet> constructorStanding)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO constructor_standings ({nameof(ConstructorStandingPsql.constructor_standing_Id)},{nameof(ConstructorStandingPsql.race_Id)},{nameof(ConstructorStandingPsql.constructor_Id)},{nameof(ConstructorStandingPsql.constructor_standing_Points)},{ nameof(ConstructorStandingPsql.constructor_standing_Position)},{nameof(ConstructorStandingPsql.constructor_standing_Position_Text)},{nameof(ConstructorStandingPsql.constructor_standing_Wins)}) ");
        sb.Append("Values ");
        foreach (var i in constructorStanding)
        {
            Constructor_standing item = (Constructor_standing) i;
            sb.AppendLine(
                $"({item.constructorStandingsId},'{item.raceId}','{item.constructorId}','{item.points}','{item.position}','{item.positionText}','{item.wins}'),"); 
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "0");
        sb.Append(";");
        return sb.ToString();
    }
    private static string GenerateRacesInsert(IEnumerable<ISheet> races)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO races ({nameof(RacePsql.race_Id)},{nameof(RacePsql.race_Year)},{nameof(RacePsql.race_Round)},{nameof(RacePsql.circuit_Id)},{nameof(RacePsql.race_Name)},{nameof(RacePsql.race_Date)},{nameof(RacePsql.race_Time)}) ");
        sb.Append("Values ");
        foreach (var i in races)
        {
            Race item = (Race) i;
            sb.AppendLine(
                $"({item.raceId},{item.year},{item.round},{item.circuitId},'{item.name}','{item.date}','{HandleTimeSpan(item.time)}'),"); 
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "0");
        sb.Append(";");
        return sb.ToString();
    }

    private static string GenerateDriverStandingInsert(IEnumerable<ISheet> driver_standings)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO driver_standings ({nameof(DriverStandingPsql.driver_standing_Id)},{nameof(DriverStandingPsql.race_Id)},{nameof(DriverStandingPsql.driver_Id)},{nameof(DriverStandingPsql.driver_standing_points)},{nameof(DriverStandingPsql.driver_standing_position)},{nameof(DriverStandingPsql.driver_standing_position_Text)},{nameof(DriverStandingPsql.driver_standing_wins)}) ");
        sb.Append("Values ");
        foreach (var i in driver_standings)
        {
            Driver_standing item = (Driver_standing) i;
            sb.AppendLine(
                $"({item.driverStandingsId},{item.raceId},{item.driverId},{item.points},'{item.position}','{item.positionText}','{HandleTimeSpan(item.wins)}'),"); 
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "0");
        sb.Append(";");
        return sb.ToString();
    }
    
    private static string GenerateLapTimeInsert(IEnumerable<ISheet> lap_times)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO lap_times ({nameof(LapTimePsql.race_Id)},{nameof(LapTimePsql.driver_Id)},{nameof(LapTimePsql.lap)},{nameof(LapTimePsql.lap_time_position)},{nameof(LapTimePsql.lap_time_time)} ");
        sb.Append("Values ");
        foreach (var i in lap_times)
        {
            Lap_time item = (Lap_time) i;
            sb.AppendLine(
                $"({item.raceId},{item.driverId},{item.lap},{item.position},'{HandleTimeSpan(item.time)}'),"); 
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "0");
        sb.Append(";");
        return sb.ToString();
    }
    
    private static string GenerateQualifyingInsert(IEnumerable<ISheet> qualifyings)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO qualifyings ({nameof(QualifyingPsql.qualifying_Id)},{nameof(QualifyingPsql.race_Id)},{nameof(QualifyingPsql.driver_Id)},{nameof(QualifyingPsql.constructor_Id)},{nameof(QualifyingPsql.qualifying_position)},{nameof(QualifyingPsql.qualifying_q1)},{nameof(QualifyingPsql.qualifying_q2)},{nameof(QualifyingPsql.qualifying_q3)})");
        sb.Append("Values ");
        foreach (var i in qualifyings)
        {
            Qualifying item = (Qualifying) i;
            sb.AppendLine(
                $"({item.qualifyId},{item.raceId},{item.driverId},{item.constructorId},'{item.position}','{HandleTimeSpan(item.q1)}','{HandleTimeSpan(item.q2)}','{HandleTimeSpan(item.q3)}'),"); 
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "0");
        sb.Append(";");
        return sb.ToString();
    }
    
    private static string GenerateResultInsert(IEnumerable<ISheet> results)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO results ({nameof(ResultPsql.result_Id)},{nameof(ResultPsql.race_Id)},{nameof(ResultPsql.driver_Id)},{nameof(ResultPsql.constructor_Id)},{nameof(ResultPsql.result_Number)},{nameof(ResultPsql.result_Grid)},{nameof(ResultPsql.result_Position)},{nameof(ResultPsql.result_Position_Text)},{nameof(ResultPsql.result_Position_Order)},{nameof(ResultPsql.result_Points)})");
        sb.Append("Values ");
        foreach (var i in results)
        {
            Result item = (Result) i;
            sb.AppendLine(
                $"({item.resultId},{item.raceId},{item.driverId},{item.constructorId},'{item.number}','{item.grid}','{item.position}','{item.positionText}','{item.positionOrder}','{item.points}'),"); 
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "0");
        sb.Append(";");
        return sb.ToString();
    }
    
    private static string GenerateSprintResultInsert(IEnumerable<ISheet> sprint_results)
    {
        var sb = new StringBuilder();
        sb.Append(
            $"INSERT INTO sprint_results ({nameof(SprintResultPsql.sprint_resultId)},{nameof(SprintResultPsql.race_Id)},{nameof(SprintResultPsql.driver_Id)},{nameof(SprintResultPsql.constructor_Id)},{nameof(SprintResultPsql.sprint_result_number)},{nameof(SprintResultPsql.sprint_result_grid)},{nameof(SprintResultPsql.sprint_result_position)},{nameof(SprintResultPsql.sprint_result_position_text)},{nameof(SprintResultPsql.sprint_result_position_order)},{nameof(SprintResultPsql.rsprint_result_points)})");
        sb.Append("Values ");
        foreach (var i in sprint_results)
        {
            Sprint_result item = (Sprint_result) i;
            sb.AppendLine(
                $"({item.resultId},{item.raceId},{item.driverId},{item.constructorId},'{item.number}','{item.grid}','{item.position}','{item.positionText}','{item.positionOrder}','{item.points}'),"); 
        }

        sb.Remove(sb.Length - 2, 2);
        sb.Replace("\\N", "0");
        sb.Append(";");
        return sb.ToString();
    }

    private static string HandleTimeSpan(string time)
    {
        return (time == "\\N") ? (new TimeSpan(0, 0, 0).ToString()) 
            : (time == "" ? (new TimeSpan(0, 0, 0).ToString()) : time);
    }
}