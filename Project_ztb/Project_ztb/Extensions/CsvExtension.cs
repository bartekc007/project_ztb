using System.Collections;
using CsvHelper;
using Project_ztb.Entities;
using Project_ztb.Entities.Common;

namespace Project_ztb.Extensions;

public static class QuerySheetGenerator
{

    private static IDictionary<string, Func<CsvReader, IEnumerable>> QueryGenerator =
        new Dictionary<string, Func<CsvReader,  IEnumerable>>
        {
            {"circuits", GetCircuitQuery},
            {"constructors", GetConstructorsQuery},
            {"constructor_results", GetConstructor_resultsQuery},
            {"constructor_standings", GetConstructor_standingQuery},
            {"races", GetRacesQuery},
            {"status", GetStatusQuery},
            {"drivers", GetDriversQuery},
            {"driver_standings", GetDriver_StandingsQuery },
            {"lap_times",GetLap_TimesQuery},
            {"qualifying",GetQualifyingQuery},
            {"results",GetResultQuery},
            {"sprint_results",GetSprintResultQuery}
        };

    public static IEnumerable<ISheet> Generate(string sheet,CsvReader csv)
    {
        if(QueryGenerator.ContainsKey(sheet.ToString()))
            return (IEnumerable<ISheet>)QueryGenerator[sheet].Invoke(csv);
        return null;
    }
    
    private static IEnumerable<Circuit> GetCircuitQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Circuit>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Circuit>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
    
    private static IEnumerable<Driver> GetDriversQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Driver>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Driver>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
    private static IEnumerable<Constructor> GetConstructorsQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Constructor>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Constructor>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
    
    private static IEnumerable<Constructor_results> GetConstructor_resultsQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Constructor_results>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Constructor_results>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
    private static IEnumerable<Constructor_standing> GetConstructor_standingQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Constructor_standing>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Constructor_standing>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
    
    private static IEnumerable<Race> GetRacesQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Race>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Race>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
    
    private static IEnumerable<Status> GetStatusQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Status>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Status>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
    
    private static IEnumerable<Driver_standing> GetDriver_StandingsQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Driver_standing>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Driver_standing>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
    
    private static IEnumerable<Lap_time> GetLap_TimesQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Lap_time>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Lap_time>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
    
    private static IEnumerable<Qualifying> GetQualifyingQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Qualifying>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Qualifying>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
    
    private static IEnumerable<Result> GetResultQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Result>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Result>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
    
    private static IEnumerable<Sprint_result> GetSprintResultQuery( CsvReader csv)
    {
        var query = csv.GetRecords<Sprint_result>();
        
        if (Parameters.GetNumberOfRecords().HasValue)
            query = query.Take<Sprint_result>(Parameters.GetNumberOfRecords().Value);
        return query;
    }
}