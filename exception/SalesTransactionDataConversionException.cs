using System;
namespace helloworld
{
    public class SalesTransactionDataConversionException : Exception
    {
        public SalesTransactionDataConversionException(string message, Exception inner) : base(message, inner)
        {
            
        }

    }
}
