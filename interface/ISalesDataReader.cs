namespace SalesImport
{
    public interface ISalesDataReader
    {
        SalesTransaction ReadData();

        bool IsEndOfData();
    }

}