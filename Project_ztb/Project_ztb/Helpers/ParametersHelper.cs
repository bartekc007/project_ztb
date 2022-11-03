using Project_ztb.Entities;
using Project_ztb.Entities.Common;

namespace Project_ztb.Helpers;

public static class ParametersHelper
{
    public static void AssignParametters(string[] args)
    {
        if (args.Length % 2 == 1)
            throw new ArgumentException("Invalid number of arguments");
        
        for (int i = 0; i < args.Length; i++)
        {
            CheckIfDbEntity(args[i],args[i+1]);
            CheckIfSelectedTable(args[i],args[i+1]);
            CheckIfNumberOfRecords(args[i],args[i+1]);
            i++;
        }

        if (Parameters.GetDbTable()==null)
            ParametersHelper.CheckInAllSheets();
    }

    private static void CheckInAllSheets()
    {
        foreach (CsvSheet sheet in (CsvSheet[]) Enum.GetValues(typeof(CsvSheet)))
            Parameters.SetDbTable(sheet.ToString());
    }

    private static void CheckIfDbEntity(string param, string value)
    {
        if (param.Equals("-d", StringComparison.InvariantCultureIgnoreCase) ||
            param.Equals("--database", StringComparison.InvariantCultureIgnoreCase))
        {
            if(!string.IsNullOrEmpty(value))
                Parameters.SetDbEntity(value);
        }
    }
    
    private static void CheckIfSelectedTable(string param, string value)
    {
        if (param.Equals("-t", StringComparison.InvariantCultureIgnoreCase) ||
            param.Equals("--table", StringComparison.InvariantCultureIgnoreCase))
        {
            if(!string.IsNullOrEmpty(value))
                Parameters.SetDbTable(value);
        }
    }
    
    private static void CheckIfNumberOfRecords(string param, string value)
    {
        if (param.Equals("-n", StringComparison.InvariantCultureIgnoreCase) ||
            param.Equals("--number", StringComparison.InvariantCultureIgnoreCase))
        {
            if(!string.IsNullOrEmpty(value))
                Parameters.SetNumberOfRecords(value);
        }
    }
}