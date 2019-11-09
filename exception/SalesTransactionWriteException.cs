using System;
namespace SalesImport
{
    public class SalesTransactionWriteException : Exception
    {
        public SalesTransactionWriteException(string message, Exception inner) : base(message, inner)
        {
            
        }

    }
}
