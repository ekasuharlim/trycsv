namespace helloworld
{
    public interface ISalesDataReader
    {
        SalesTransaction ReadData();

        bool IsEndOfData();
    }

}