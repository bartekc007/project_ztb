namespace Project_ztb.Entities.Common;

public static class Parameters
{
    private static DBEntity? DbEntity;
    private static List<CsvSheet> SelectedTable = new List<CsvSheet>();
    private static int? NumberOfRecords;

    public static void SetDbEntity(string db)
    {
        if (!string.IsNullOrEmpty(db))
        {
            if ("postgres".Equals(db, StringComparison.InvariantCultureIgnoreCase))
                DbEntity = DBEntity.Postgres;
            if ("mongodb".Equals(db, StringComparison.InvariantCultureIgnoreCase))
                DbEntity = DBEntity.MongoDb;
        }
    }

    public static string GetDbEntity()
    {
        if (DbEntity.HasValue)
        {
            if (DbEntity == DBEntity.Postgres)
                return "postgres";
            if (DbEntity == DBEntity.MongoDb)
                return "mongodb";
        }
        return "postgres";
    }

    public static void SetDbTable(string table)
    {
        if (!string.IsNullOrEmpty(table))
        {
            if ("circuits".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.circuits);
            if ("constructors".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.constructors);
            if ("constructor_results".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.constructor_results);
            if ("constructor_standings".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.constructor_standings);
            if ("drivers".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.drivers);
            if ("driver_standings".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.driver_standings);
            if ("lap_times".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.lap_times);
            if ("qualifying".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.qualifying);
            if ("races".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.races);
            if ("results".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.results);
            if ("sprint_results".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.sprint_results);
            if ("status".Equals(table, StringComparison.InvariantCultureIgnoreCase))
                SelectedTable.Add(CsvSheet.status);        
        }
    }
    
    public static IEnumerable<CsvSheet> GetDbTable()
    {
        if (SelectedTable.Count > 0)
            return SelectedTable;
        return null;
    }

    public static void SetNumberOfRecords(string number)
    {
        if (!string.IsNullOrEmpty(number))
        {
            int temp = 0;
            if (int.TryParse(number, out temp))
                NumberOfRecords = temp;
        }
    }

    public static int? GetNumberOfRecords()
    {
        return NumberOfRecords;
    }
}

public enum DBEntity
{
    Postgres = 0,
    MongoDb = 1
}

public enum CsvSheet
{
    circuits = 0,
    constructors = 1,
    constructor_results = 2,
    constructor_standings =3,
    drivers =4,
    driver_standings=5,
    lap_times=6,
    qualifying=7,
    races=8,
    results=9,
    sprint_results=10,
    status=11
}

public enum DbTable
{
    Circuits = 0,
    Constructors = 1,
    Constructor_Results = 2,
    Constructor_Standing =3,
    Drivers =4,
    Driver_Standings=5,
    Lap_Times=6,
    Qualifyng=7,
    Races=8,
    Results=9,
    Sprint_Results=10,
    Status=11
}