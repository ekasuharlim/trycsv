using System;
namespace helloworld
{
    public class SalesTransactionWriteException : Exception
    {
        public SalesTransactionWriteException(string message, Exception inner) : base(message, inner)
        {
            
        }

    }
}
