using System.Globalization;
using System.Linq;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Project_ztb.Entities;
using Project_ztb.Entities.Common;
using Project_ztb.Extensions;
using Project_ztb.Helpers;
using Project_ztb.ScriptGenerators;


public class Program
{
    static void Main(string[] args)
    {
        ParametersHelper.AssignParametters(args);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
        };

        try
        {
            foreach (var s in Parameters.GetDbTable().ToList())
            {
                var sheet = s.ToString().ToLower();
                List<ISheet> records;
                using (var reader = new StreamReader($"../../../../../Data/{sheet}.csv"))
                using (var csv = new CsvReader(reader, config))
                {
                    var query = QuerySheetGenerator.Generate(sheet,csv);
                    records = query?.ToList();
                }

                if (records != null)
                {
                    var generator = new PostgresScriptGenerator();
                    generator.GenerateFile(s,records); 
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}


