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
            {"races",GenerateRacesInsert}
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
                $"({item.circuitId},'{item.circuitRef}','{item.name}','{item.location}',{item.lat},{item.lng},{item.alt}),"); 
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
                $"({item.driverId},'{item.driverRef}','{item.number}','{item.code}','{item.forename}','{item.surname}','{item.dob}','{item.nationality}'),"); 
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

    private static string HandleTimeSpan(string time)
    {
        return (time == "\\N") ? (new TimeSpan(0, 0, 0).ToString()) : time;
    }
}