using Project_ztb.Entities.Common;

namespace Project_ztb.ScriptGenerators;

public interface IScriptGenerator
{
    void GenerateFile(CsvSheet sheet, IEnumerable<ISheet> records);
}