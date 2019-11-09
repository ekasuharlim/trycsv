namespace SalesImport
{
    public interface ISalesDataWriter
    {
        void WriteData(SalesTransaction salesTransaction);
    }

}