using Microsoft.VisualBasic.FileIO;

namespace helloworld
{
public class SalesDataReader
{
    public void ReadData(string dataFilePath,ILogger logger)
    {
        var csvParser = new TextFieldParser(dataFilePath);
        csvParser.SetDelimiters(new string[] {","});
        csvParser.HasFieldsEnclosedInQuotes = true;
        string[] fields;
        fields = csvParser.ReadFields();
        foreach(string field in fields)
        {
            logger.WriteLogInfo(field);
        }
    }
}
}
