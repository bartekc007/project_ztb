using Newtonsoft.Json;
using Project_ztb.Entities.Common;

namespace Project_ztb.ScriptGenerators;

public class MongoScriptGenerator : IScriptGenerator
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
    
    public void GenerateFile(CsvSheet sheet, IEnumerable<ISheet> records)
    {
        if (generators.ContainsKey(sheet.ToString()))
        {
            string fileName ="mongo_" + sheet.ToString() + "_" + (Parameters.GetNumberOfRecords().HasValue
                ? Parameters.GetNumberOfRecords().Value.ToString()
                : "All");
            string path = $"../../../../../Scripts/Mongo/{fileName}.txt";
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
        return "db.circuits.insertMany(" + JsonConvert.SerializeObject(circuits) + ");";
    }
    
    private static string GenerateDriversInsert(IEnumerable<ISheet> drivers)
    {
        return "db.drivers.insertMany(" + JsonConvert.SerializeObject(drivers) + ");";
    }
    private static string GenerateStatusesInsert(IEnumerable<ISheet> statuses)
    {
        return "db.statuses.insertMany(" + JsonConvert.SerializeObject(statuses) + ");";
    }
    private static string GenerateConstructorsInsert(IEnumerable<ISheet> constructors)
    {
        return "db.constructors.insertMany(" + JsonConvert.SerializeObject(constructors) + ");";
    }
    private static string GenerateConstructorResultsInsert(IEnumerable<ISheet> constructorsResults)
    {
        return "db.constructorsResults.insertMany(" + JsonConvert.SerializeObject(constructorsResults) + ");";
    }
    private static string GenerateConstructorStandingsInsert(IEnumerable<ISheet> constructorStanding)
    {
        return "db.constructorStanding.insertMany(" + JsonConvert.SerializeObject(constructorStanding) + ");";
    }
    private static string GenerateRacesInsert(IEnumerable<ISheet> races)
    {
        return "db.races.insertMany(" + JsonConvert.SerializeObject(races) + ");";
    }

    private static string GenerateDriverStandingInsert(IEnumerable<ISheet> driver_standings)
    {
        return "db.driver_standings.insertMany(" + JsonConvert.SerializeObject(driver_standings) + ");";
    }
    
    private static string GenerateLapTimeInsert(IEnumerable<ISheet> lap_times)
    {
        return "db.lap_times.insertMany(" + JsonConvert.SerializeObject(lap_times) + ");";
    }
    
    private static string GenerateQualifyingInsert(IEnumerable<ISheet> qualifyings)
    {
        return "db.qualifyings.insertMany(" + JsonConvert.SerializeObject(qualifyings) + ");";
    }
    
    private static string GenerateResultInsert(IEnumerable<ISheet> results)
    {
        return "db.results.insertMany(" + JsonConvert.SerializeObject(results) + ");";
    }
    
    private static string GenerateSprintResultInsert(IEnumerable<ISheet> sprint_results)
    {
        return "db.sprint_results.insertMany(" + JsonConvert.SerializeObject(sprint_results) + ");";
    }
}